function comments(input){
   class Comment{
        constructor(title,content){
            this.title = title,
            this.content = content
        }
    }
    class User {
        constructor(name){
            this.name = name
        }
    }
    class Article{
        constructor(name){
            this.name = name,
            this.comments = []
        }
    }
    let users = [];
    let articles = [];
    input.reduce((acc,curr) => {
        if(curr.split(' ')[0]==='user'){
           const name = curr.split(' ')[1];
           const user = new User(name);
           users.push(user);
        }
        else if(curr.split(' ')[0] === 'article'){
           const name = curr.split(' ')[1];
           const article = new Article(name);
           articles.push(article);
        }
        else{
           const postInfo = curr.split(': ')[0];
           const commentInfo = curr.split(': ')[1];
           const username = postInfo.split(' ')[0];
           const articleName = postInfo.split(' ')[3];
           if(users.find((user)=>user.name===username)!==undefined
           && articles.find((article)=>article.name===articleName)){
            const commentTitle = commentInfo.split(', ')[0];
            const commentContent = commentInfo.split(', ')[1];
            const comment = new Comment(commentTitle,commentContent);
            articles.find((article)=>article.name===articleName).comments.push(
                [users.find((user)=>user.name===username),comment]
            );
           }
        }
        acc=articles;
        return acc;
    },[]).sort((a,b)=>b.comments.length - a.comments.length).forEach((article) => {
        console.log(`Comments on ${article.name}`);
        article.comments.sort((a,b)=>a[0].name.localeCompare(b[0].name)).forEach((comment)=>{
            console.log(`--- From user ${comment[0].name}: ${comment[1].title} - ${comment[1].content}`);
        })
    })
}