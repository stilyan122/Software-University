function fruit(fruit, weight, price) {
    weight /= 1000;
    let money = weight * price;

    console.log(`I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}

function GCD(num1, num2) {
    while (num2 !== 0) {
        let reminder = num1 % num2;
        num1 = num2;
        num2 = reminder;
    }

    console.log(num1);
}

function sameNumbers(num) {
    let sum = 0;
    let toString = num.toString();
    let firstNumber = toString[0];
    let result = true;

    for (let i = 0; i < toString.length; i++) {
        let currentNumber = Number(toString[i]);
        sum += currentNumber;
        
        if (currentNumber != firstNumber) {
            result = false;
        }
    }

    console.log(result);
    console.log(sum);
}

function previousDay(year, month, day) {
    let monthIndex = month - 1;
    let dayIndex = day - 1;
    let date = new Date(year, monthIndex, dayIndex);
    console.log(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`);
}

function timeToWalk(steps, length, speed) {
    let stepsCount = steps * length;
    let correctSpeed = speed * 1000 / 3600;
    let breaksCount = Math.floor(stepsCount / 500);
    let time = stepsCount / correctSpeed;

    let totalTime = time + breaksCount * 60;

    let hours = Math.floor(totalTime / 3600);
    totalTime -= hours * 3600;

    let minutes = Math.floor(totalTime / 60);
    totalTime -= minutes * 60;

    let seconds = Math.round(totalTime);

    let hoursToStr = hours.toString().padStart(2, '0');
    let minutesToStr = minutes.toString().padStart(2, '0');
    let secondsToStr = seconds.toString().padStart(2, '0');

    console.log(`${hoursToStr}:${minutesToStr}:${secondsToStr}`);
}

function roadRadar(speed, area) {
    let speedLimit = 0;

    if (area === 'motorway') {
        speedLimit = 130;
    } else if (area === 'interstate') {
        speedLimit = 90;
    } else if (area === 'city') {
        speedLimit = 50;
    } else if (area === 'residential') {
        speedLimit = 20;
    }

    if (speed <= speedLimit) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    } else{
        let status = " ";
        let diff = speed - speedLimit;

        if (diff <= 20) {
          status = "speeding";   
        } else if (diff <= 40) {
          status = "excessive speeding";   
        } else {
          status = "reckless driving";
        }

        console.log(`The speed is ${diff} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}

function cookingByNumbers(start, op1, op2, op3, op4, op5) {
    let number = parseFloat(start);

    function changeNumber(num, op) {
        let result = 0;

        if (op === 'chop') {
            result = num / 2;
        } else if (op === 'dice') {
            result = Math.sqrt(num);
        } else if (op === 'spice') {
            result = num + 1;
        } else if (op === 'bake') {
            result = num * 3;
        } else if (op === 'fillet') {
            result = (num * 0.80).toFixed(1);
        }

        console.log(result);

        return parseFloat(result);
    }

    number = changeNumber(number, op1);
    number = changeNumber(number, op2);
    number = changeNumber(number, op3);
    number = changeNumber(number, op4);
    number = changeNumber(number, op5);
}

function validityChecker(x1, y1, x2, y2) {
    let value1 = Math.sqrt((0 - x1) ** 2 + (0 - y1) ** 2);
    let value2 = Math.sqrt((0 - x2) ** 2 + (0 - y2) ** 2);
    let value3 = Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);

    if (Number.isInteger(value1)) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else{
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if (Number.isInteger(value2)) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else{
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if (Number.isInteger(value3)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else{
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

function wordsUppercase(str) {
    let words = str.match(/\b\w+\b/g);

    words = words.map(element => {
        return element.toUpperCase();
    });

    console.log(words.join(', '));
}