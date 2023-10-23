function calculate(x1,y1,x2,y2) {
    let number1 = Math.sqrt((x1*x1)+(y1*y1));
    if (Number.isInteger(number1)) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    }
    else{
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }
    let number2 = Math.sqrt((x2*x2)+(y2*y2));
    if (Number.isInteger(number2)) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    }
    else{
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }
    let number3 = Math.sqrt((x2-x1)*(x2-x1)+(y2-y1)*(y2-y1));
    if (Number.isInteger(number3)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    }
    else{
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}