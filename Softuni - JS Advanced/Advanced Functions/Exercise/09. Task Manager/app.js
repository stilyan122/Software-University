function solve() {
    function createEl(tag, content)
    {
        let el = document.createElement(tag);
        el.textContent = content;
        return el;
    }

    function addFunction(e){
        e.preventDefault();

        let inputTask = document.getElementById('task');
        let inputDescription = document.getElementById('description');
        let inputDate = document.getElementById('date');

        let openSection = document.getElementsByTagName('section')[1]
            .getElementsByTagName('div')[1];
        let inProgressSection = document.getElementsByTagName('section')[2]
            .getElementsByTagName('div')[1];
        let completeSection = document.getElementsByTagName('section')[3]
            .getElementsByTagName('div')[1];

        if(inputTask.value == '' || inputDescription.value == '' || inputDate.value == '')
        {
            return;
        }

        let article = document.createElement('article');

        let task = createEl('h3', inputTask.value);
        let desc = createEl('p', `Description: ${inputDescription.value}`);
        let dueDate = createEl('p', `Due Date: ${inputDate.value}`);

        let div = document.createElement('div');
        div.classList.add('flex');  

        let startBtn = createEl('button', 'Start');
        let deleteBtn = createEl('button', 'Delete');

        startBtn.classList.add('green');
        deleteBtn.classList.add('red');

        startBtn.addEventListener('click', function(e){
            e.preventDefault();

            openSection.removeChild(article);
            
            let finishBtn = createEl('button', 'Finish');
            finishBtn.classList.add('orange');

            finishBtn.addEventListener('click', function(e){
                e.preventDefault();
    
                inProgressSection.removeChild(article);
                article.removeChild(div);
    
                completeSection.appendChild(article);
            });

            div.removeChild(startBtn);
            div.appendChild(finishBtn);

            inProgressSection.appendChild(article);
        });

        deleteBtn.addEventListener('click', function(e){
            e.preventDefault();
            let parentSection = article.parentElement;
            parentSection.removeChild(article);
        });

        div.appendChild(startBtn);
        div.appendChild(deleteBtn);

        article.appendChild(task);
        article.appendChild(desc);
        article.appendChild(dueDate);
        article.appendChild(div);

        openSection.appendChild(article);
    }

    let addBtn = document.getElementById('add');

    addBtn.addEventListener('click', addFunction);
}