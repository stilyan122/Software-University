function subtract() {
    let firstField = document.getElementById('firstNumber');
    let secondField = document.getElementById('secondNumber');
    let resultField = document.getElementById('result');

    let firstValue = parseFloat(firstField.value);
    let secondValue = parseFloat(secondField.value);

    let result = firstValue - secondValue;
    resultField.innerHTML += result;
}