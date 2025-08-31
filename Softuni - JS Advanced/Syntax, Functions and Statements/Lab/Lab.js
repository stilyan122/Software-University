function echo(param){
    console.log(param.length);
    console.log(param);
}

function stringLength(str1, str2, str3){
    let sum = str1.length + str2.length + str3.length;
    let average = Math.floor(sum / 3);

    console.log(sum);
    console.log(average);
}

function largestNumber(num1, num2, num3){
    let max = Math.max(num1, num2, num3);

    console.log(`The largest number is ${max}.`);
}

function circleArea(argument){
    if (typeof argument === 'number'){
        let area = argument ** 2 * Math.PI;
        console.log(`${area.toFixed(2)}`);
    } else{
        console.log(`We can not calculate the circle area, because we receive a ${typeof argument}.`)
    }
}

function mathOperations(num1, num2, operation){
    let result;

    switch (operation) {
        case '+':
            result = num1 + num2;
            break;
        case '-':
            result = num1 - num2;
            break;
        case '%':
            result = num1 % num2;
            break;
         case '*':
            result = num1 * num2;
            break;
        case '/':
            result = num1 / num2;
            break;
        case '**':
            result = num1 ** num2;
            break;
    }

    console.log(result);
}

function sumNumbers(num1, num2) {
    let number1 = Number(num1);
    let number2 = Number(num2);
    let sum = 0;

    for (let i = number1; i <= number2; i++) {
        sum+=i;
    }

    console.log(sum);
}

function daysOfWeek(day) {
    let num = 0;

    switch (day) {
        case 'Monday':
            num = 1;
            break;
        case 'Tuesday':
            num = 2;
            break;
        case 'Wednesday':
            num = 3;
            break;
        case 'Thursday':
            num = 4;
            break;
        case 'Friday':
            num = 5;
            break;
        case 'Saturday':
            num = 6;
            break;
        case 'Sunday':
            num = 7;
            break;    
        default:
            num = 'error';
            break;
    }

    console.log(num);
}

function daysInMonth(month, year){
    let date = new Date(year, month, 0);

    console.log(date.getDate());
}

function squareOfStars(num){
    for (let i = 0; i < num; i++) {
        let stars = "";
        for (let j = 0; j < num; j++) {
            stars+="* ";
        }
        console.log(stars);
    }
}

function aggregateElements(array) {
    function sum(array) {
        let sum = 0;

        array.forEach(element => {
            sum += element;
        });

        console.log(sum);
    }

    function inverseSum(array) {
        let sum = 0;
        
        array.forEach(element => {
            sum += 1 / element;
        });

        console.log(sum);   
    }

    function concat(array){
        let sum = '';

        array.forEach(element => {
            sum += String(element);
        });

        console.log(sum);
    }
    
    sum(array);
    inverseSum(array);
    concat(array);
}