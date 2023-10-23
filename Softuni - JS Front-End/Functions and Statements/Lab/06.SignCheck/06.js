function checkingAResultSign(number1,number2,number3) {
    if ((number1<0||number2<0||number3<0)
    && ((number1>0&&number2>0)||(number1>0&&number3>0)||(number2>0&&number3>0))) {
        console.log("Negative");
    }
    else if (((number1<0&&number2<0)||(number1<0&&number3<0)||(number2<0&&number3<0))
    && (number1>0||number2>0||number3>0)){
        console.log("Positive");
    }
    else if(number1>0&&number2>0&&number3>0){
        console.log("Positive");
    }
    else if (number1<0&&number2<0&&number3<0) {
        console.log("Negative");
    }
}