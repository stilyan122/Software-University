function attachEvents() {
    const sendBtn = document.getElementById('submit');
    const refreshBtn = document.getElementById('refresh');

    const textarea = document.getElementById('messages');

    const controls = document.getElementById('controls');

    sendBtn.addEventListener('click',function() {
       const URL = 'http://localhost:3030/jsonstore/messenger';
       const nameDiv = controls.getElementsByTagName('div')[0];
       const messageDiv = controls.getElementsByTagName('div')[1];

       const name = nameDiv.getElementsByTagName('input')[0].value;
       const message = messageDiv.getElementsByTagName('input')[0].value;
       
       nameDiv.getElementsByTagName('input')[0].value = '';
       messageDiv.getElementsByTagName('input')[0].value = '';
       const messageObj = {
        author: name,
        content: message,
       }
       fetch(URL, {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(messageObj),
        });
    });

    refreshBtn.addEventListener('click',function(){
        const URL = 'http://localhost:3030/jsonstore/messenger';
        fetch(URL)
        .then((res)=>{
            res.json()
            .then((json)=>{
                textarea.textContent='';
                const length = Object.values(json).length;
                let counter = 0;
                for (const message of Object.values(json)) {
                    if(counter<length-1)
                    textarea.textContent+=`${message.author}: ${message.content}\n`;
                    else
                    textarea.textContent+=`${message.author}: ${message.content}`;

                    counter++;
                }
            })
        })
    });
}

attachEvents();