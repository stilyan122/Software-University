function calculator(number1,number2,operator) {
    let result;
    switch (operator) {
        case 'multiply':
            result = (number1,number2) => number1 * number2;
        break;
        case 'divide':
            result = (number1,number2) => number1 / number2;
        break;
        case 'add':
            result = (number1,number2) => number1 + number2;
        break;
        case 'subtract':
            result = (number1,number2) => number1 - number2;
        break;
    }
    console.log(result(number1,number2));
    /*No conditional statements:
    const calculator = (num1, num2, operator) => ({
    'multiply': num1 * num2,
    'divide': num1 / num2,
    'add': num1 + num2,
    'subtract': num1 - num2
    */
}