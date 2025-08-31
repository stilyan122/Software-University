function solve() {
    function checkForValidSudoku(sudokuArray){
        let sudokuMatrix = [];
        let isValid = true;

        for (let i = 0; i < 3; i++) {
            let row = sudokuArray.slice(i * 3, (i + 1) * 3);
            sudokuMatrix.push(row);
        }

        for (let i = 0; i < 3; i++) {
            let row = sudokuMatrix[i];
            let col = sudokuMatrix.map(x => x[i]);
            let rowSet = new Set(row);
            let colSet = new Set(col);

            if(rowSet.size !== 3 || colSet.size !== 3){
                isValid = false;
                break;
            }
        }

        return isValid;
    }

    let container = document.getElementById('exercise');
    let table = container.getElementsByTagName('table')[0];

    let tfoot = table.getElementsByTagName('tfoot')[0];
    let tbody = table.getElementsByTagName('tbody')[0];

    let checkDiv = document.getElementById('check');
    let checkText = checkDiv.getElementsByTagName('p')[0];

    let checkButton = tfoot.getElementsByTagName('button')[0];
    let clearButton = tfoot.getElementsByTagName('button')[1];

    let inputs = tbody.getElementsByTagName('input');

    checkButton.addEventListener('click', function () {
        let inputValuesAsArray = Array.from(inputs).map(x => x.value);
        let validSudoku = checkForValidSudoku(inputValuesAsArray);
       
        if (validSudoku){
            table.style.border = '2px solid green';
            checkText.textContent = 'You solve it! Congratulations!';
            checkText.style.color = 'green';
        } else {
            table.style.border = '2px solid red';
            checkText.textContent = 'NOP! You are not done yet...';
            checkText.style.color = 'red';
        }
    });

    clearButton.addEventListener('click', function () {
        Array.from(inputs).map(x => x.value = '');
        table.style.border = '';
        checkButton.style.color = '';
        checkText.textContent = '';
    });
}