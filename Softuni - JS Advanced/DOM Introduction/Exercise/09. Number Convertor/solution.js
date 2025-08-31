function solve() {
    let selectMenuTO = document.getElementById('selectMenuTo');
    
    function addSelectOptions() {
        let firstOption = document.createElement('option');
        let secondOption = document.createElement('option');

        firstOption.textContent = 'Binary';
        secondOption.textContent = 'Hexadecimal';
        firstOption.value = 'binary';
        secondOption.value = 'hexadecimal';

        selectMenuTO.appendChild(firstOption);
        selectMenuTO.appendChild(secondOption);
    }

    function displayResult() {
        let inputField = document.getElementById('input');
        let decimalValue = parseInt(inputField.value);
        let choice = selectMenuTO.value;
        let output = '';

        if (choice === 'binary') {
            output = decimalValue.toString(2);
        } else if (choice === 'hexadecimal') {
            output = decimalValue.toString(16).toUpperCase();
        }

        let resultField = document.getElementById('result');
        resultField.value = output; 
    }

    let appContainer = document.getElementById('container');
    let resultButton = appContainer.getElementsByTagName('button')[0];

    addSelectOptions();

    resultButton.addEventListener('click', displayResult);
}