function solve() {
    let onScreenBtn = document.querySelector('#container button');
    let clearBtn = document.querySelector('#archive button');

    onScreenBtn.addEventListener('click', onScreen);

    function createEl(tag, content)
    {
        let el = document.createElement(tag);
        el.textContent = content;
        return el;
    }

    function onScreen(e) {
        e.preventDefault();

        let movieNameField = document.querySelector('#container input[placeholder="Name"]');
        let hallField = document.querySelector('#container input[placeholder="Hall"]');
        let priceField = document.querySelector('#container input[placeholder="Ticket Price"]');

        let movieName = movieNameField.value;
        let hall = hallField.value;
        let price = priceField.value;

        if(movieName === '' || hall === '' || price === '' || isNaN(parseFloat(price))) {
            return;
        }

        let moviesUl = document.querySelector('#movies ul');

        let liElement = document.createElement('li');
        let movieEl = createEl('span', movieName);
        let hallEl = createEl('strong', `Hall: ${hall}`);

        let div = document.createElement('div');

        let priceEl = createEl('strong', Number(price).toFixed(2));
        let ticketsEl = createEl('input', '');
        ticketsEl.placeholder = 'Tickets Sold';
        let archiveBtn = createEl('button', 'Archive');

        archiveBtn.addEventListener('click', archive);

        function archive(e) {
            e.preventDefault();

            let ticketsSold = ticketsEl.value;
            let archiveUl = document.querySelector('#archive ul');

            if(ticketsSold === '' || isNaN(ticketsSold)) {
                return;
            }

            moviesUl.removeChild(liElement);
            liElement.removeChild(hallEl);
            liElement.removeChild(div); 

            let totalAmount = Number(priceEl.textContent) * Number(ticketsSold);
            let amountEl = createEl('strong', `Total amount: ${totalAmount.toFixed(2)}`);
            let deleteBtn = createEl('button', 'Delete'); 

            deleteBtn.addEventListener('click', (e) => {
                e.preventDefault();
                let parentUl = liElement.parentElement;
                parentUl.removeChild(liElement);
            });

            clearBtn.addEventListener('click', (e) => {
                e.preventDefault();
                let archiveUl = document.querySelector('#archive ul');
                archiveUl.innerHTML = '';
            });
            
            liElement.appendChild(amountEl);
            liElement.appendChild(deleteBtn);

            archiveUl.appendChild(liElement);
        }
        
        div.appendChild(priceEl);
        div.appendChild(ticketsEl);
        div.appendChild(archiveBtn);

        liElement.appendChild(movieEl);
        liElement.appendChild(hallEl);
        liElement.appendChild(div);

        moviesUl.appendChild(liElement);

        movieNameField.value = '';
        hallField.value = '';
        priceField.value = '';
    }
}