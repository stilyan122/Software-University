function solution() {
    const URL = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const main = document.getElementById('main');
    main.innerHTML='';
    fetch(URL)
        .then((res)=>{
        res.json()
        .then((json)=>{
            for (let index = 0; index < json.length; index++) {
                const element = json[index];
                const div = document.createElement('div');
                div.classList.add('accordion');

                const head = document.createElement('div');
                const extra = document.createElement('div');
                head.classList.add('head');
                extra.classList.add('extra');

                const headSpan = document.createElement('span');
                headSpan.textContent = element.title;
                
                const headButton = document.createElement('button');
                headButton.classList.add('button');
                headButton.textContent='More';
                headButton.id = element._id;

                head.appendChild(headSpan);
                head.appendChild(headButton);

                const extraPara = document.createElement('p');

                const URL = 'http://localhost:3030/jsonstore/advanced/articles/details/'+element._id;
                fetch(URL)
                .then((res)=>{
                    res.json()
                    .then((json)=>{
                        extraPara.textContent=json.content;
                    })
                })
                extra.appendChild(extraPara);

                headButton.addEventListener('click',function(){
                    if(headButton.textContent==='More'){
                       extra.style.display='block';
                       headButton.textContent='Less';
                    }
                    else if(headButton.textContent==='Less'){
                        extra.style.display='none';
                        headButton.textContent='More';
                    }
                });
                div.appendChild(head);
                div.appendChild(extra);

                main.appendChild(div);
            }
        })
        })
}