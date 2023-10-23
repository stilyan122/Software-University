function findingTheSmallestNumberFromThe3(number1,number2,number3) {
    let array = [number1,number2,number3];
    let smallest = Math.min(...array);
    console.log(smallest);
}