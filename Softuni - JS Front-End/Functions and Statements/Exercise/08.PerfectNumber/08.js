function perfectNumber(num) {
    let sum = 0;
    for (let index = 1; index <num; index++) {
        if (num%index===0) {
            sum+=index;
        }
    }
    if (num>0 && num===sum) {
        console.log("We have a perfect number!");
    }
    else{
        console.log("It's not so perfect.");
    }
}