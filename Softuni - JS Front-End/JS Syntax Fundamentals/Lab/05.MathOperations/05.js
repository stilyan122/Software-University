function maths(number1,number2,operation) {
    switch (operation) {
        case "+":
        console.log(number1+number2);
        break;
        case "-":
        console.log(number1-number2);
        break;
        case "*":
        console.log(number1*number2);
        break;
        case "/":
        console.log(number1/number2);
        break;
        case "%":
        console.log(number1%number2);
        break;
        case "**":
        console.log(number1**number2);
        break;
        default:
            break;
    }
}