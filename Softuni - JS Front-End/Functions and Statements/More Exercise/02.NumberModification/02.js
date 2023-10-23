function modificateNumber(num) {
    let number = num.toString();
    let sum = 0;
    for (let index = 0; index < number.length; index++) {
        let current = parseInt(number[index]);
        sum+=current;
    }
    let average = sum / number.length;
    while (average<=5) {
        number+="9";
        sum+=9;
        average = sum / number.length;
    }
    console.log(number);
}