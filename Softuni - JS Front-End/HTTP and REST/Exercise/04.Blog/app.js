function attachEvents() {
    const postButton = document.getElementById('btnLoadPosts');
    const viewButton = document.getElementById('btnViewPost');
    let posts = {};
    postButton.addEventListener('click',function(){
        const URLposts = 'http://localhost:3030/jsonstore/blog/posts';
        const list = document.getElementById('posts');
        fetch(URLposts)
        .then((res)=>{
            res.json()
            .then((json)=>{
                Object.entries(json).forEach((obj)=>{
                    const option = document.createElement('option');
                    option.value = obj[0];
                    option.textContent = obj[1].title; 
                    list.appendChild(option);
                    posts[obj[0]] = 
                    {
                        id:obj[1].id,
                        body:obj[1].body,
                        title:obj[1].title
                    };
                })
            })
        })
    });
    viewButton.addEventListener('click',function(){
        const URLcomments = 'http://localhost:3030/jsonstore/blog/comments';
        const title = document.getElementById('post-title');
        const content = document.getElementById('post-body');
        const list = document.getElementById('post-comments');
        list.innerHTML='';
        list.textContent='';
        fetch(URLcomments)
        .then((res)=>{
            res.json()
            .then((json)=>{
                const value = document.getElementById('posts').value;
                title.textContent=posts[value].title;
                content.textContent=posts[value].body;
                Object.entries(json).forEach((obj)=>{
                    const id = obj[1].postId;
                    if(posts[value].id===id){
                        const li = document.createElement('li');
                        li.textContent=obj[1].text;
                        li.id=obj[1].id;
                        list.appendChild(li);
                    }
                })
            })
        })
    });
}

attachEvents();