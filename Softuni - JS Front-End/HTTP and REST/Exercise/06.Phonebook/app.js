function attachEvents() {
    const loadBtn = document.getElementById('btnLoad');
    const createBtn = document.getElementById('btnCreate');

    loadBtn.addEventListener('click', function(){
        const URL = 'http://localhost:3030/jsonstore/phonebook';
        const list = document.getElementById('phonebook');
        list.innerHTML='';
        list.textContent='';
        fetch(URL)
        .then((res)=>{
            res.json()
            .then((json)=>{
                const values = Object.entries(json);
                for (const value of values) {
                    const li = document.createElement('li');
                    li.textContent=`${value[1].person}: ${value[1].phone}`;
                    const btn = document.createElement('button');
                    btn.textContent = 'Delete';
                    btn.addEventListener('click',function(){
                        fetch(`${URL}/${value[1]._id}`, {
                            method: 'delete',
                        })
                        .then(()=>{
                            list.removeChild(li);
                        });
                    })
                    li.appendChild(btn); 
                    list.appendChild(li);
                }
            })
        })
    });

    createBtn.addEventListener('click',function(){
        const URL = 'http://localhost:3030/jsonstore/phonebook';
        const name = document.getElementById('person').value;
        const phone = document.getElementById('phone').value;
        document.getElementById('person').value = '';
        document.getElementById('phone').value = '';
        const personObj = {
            person: name,
            phone: phone,
        };
        fetch(URL,{
            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(personObj),
        })
        .then(()=>{
         loadBtn.click();
        })
    })
}

attachEvents();