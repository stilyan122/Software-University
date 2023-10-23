function solve() {
    const table = document.querySelector('#exercise > table > tbody');
    const button = document.getElementsByTagName('tfoot')[0].getElementsByTagName('button')[0];
    const clear = document.getElementsByTagName('tfoot')[0].getElementsByTagName('button')[1];
    let cols = {};
    button.addEventListener('click',function(){
        const rows = table.getElementsByTagName('tr');
        let isValid = true;
        let counter = 0;
        for (let index = 0; index < rows.length; index++) {
            const row = rows[index];
            const cells = row.getElementsByTagName('input');
            const set = new Set();
            for (const cell of cells) {
                set.add(cell.value);
                cols[counter] = [];
                cols[counter].push(cell.value);
                if(index===counter){
                    cols[counter].push(cell.value);
                }
                counter++;
            }
            // for 9x9 sudoku - set.size!==9
            if(set.size!==rows.length){
                isValid=false;
            }
        }
        console.log(cols);
        if(isValid){
            document.getElementById('exercise').getElementsByTagName('table')[0].style.border = '2px solid green';
            document.getElementById('check').getElementsByTagName('p')[0].textContent="You solve it! Congratulations!";
            document.getElementById('check').getElementsByTagName('p')[0].style.color='green';
        }
        else{
            document.getElementById('exercise').getElementsByTagName('table')[0].style.border = '2px solid red';
            document.getElementById('check').getElementsByTagName('p')[0].textContent="NOP! You are not done yet...";
            document.getElementById('check').getElementsByTagName('p')[0].style.color='red';
        }
    });
    clear.addEventListener('click',function(){
        document.getElementById('exercise').getElementsByTagName('table')[0].style.border = 'none';
        document.getElementById('check').getElementsByTagName('p')[0].textContent='';
        Array.from(table.getElementsByTagName('td')).forEach(element => {
            element.getElementsByTagName('input')[0].value = "";
        });
    });
}
//better-working solution:
/*
function solve() {
    let inputs = document.querySelectorAll('input');
    const checkBtn = document.querySelectorAll('button')[0];
    const clear = document.querySelectorAll('button')[1];

    const table = document.querySelector('table');
    const checkPar = document.querySelectorAll('#check p')[0];

    checkBtn.style.cursor = 'pointer';
    clear.style.cursor = 'pointer';

    clear.addEventListener('click', reset);
    checkBtn.addEventListener('click', checkResult);

    function reset() {
        [...inputs].forEach(input => (input.value = ''));
        table.style.border = 'none';
        checkPar.textContent = '';
    }

    function checkResult() {
        let matrix = [
            [inputs[0].value, inputs[1].value, inputs[2].value],
            [inputs[3].value, inputs[4].value, inputs[5].value],
            [inputs[6].value, inputs[7].value, inputs[8].value]
        ];
        isSudomu = true;
        for (let i = 1; i < matrix.length; i++) {
            let row = matrix[i];
            let col = matrix.map(row => row[i]);
            if (col.length != [...new Set(col)].length || row.length != [...new Set(row)].length) {
                isSudomu = false;
                break;
            }
        }
        if (isSudomu) {
            table.style.border = '2px solid green';
            checkPar.style.color = 'green';
            checkPar.textContent = 'You solve it! Congratulations!';
        } else {
            table.style.border = '2px solid red';
            checkPar.style.color = 'red';
            checkPar.textContent = 'NOP! You are not done yet...';
        }
    }
}
*/