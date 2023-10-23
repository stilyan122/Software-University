function returnSumsOfEvensAndOdds(number) {
    let string = number.toString();
    let evenSum=0;
    let oddSum=0;
    for (let index = 0; index < string.length; index++) {
       let curr = parseInt(string[index]);
       if (curr%2===0) {
        evenSum+=curr;
       }
       else{
        oddSum+=curr;
       }
    }
    return("Odd sum = "+oddSum+", Even sum = "+evenSum);
}