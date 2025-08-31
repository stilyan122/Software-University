function calc() {
    let num1 = document.getElementById('num1');
    let num2 = document.getElementById('num2');
    let sum = document.getElementById('sum');

    let firstVal = parseFloat(num1.value);
    let secondVal = parseFloat(num2.value);
    sum.value = firstVal + secondVal;
}
