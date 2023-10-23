function makingLoadingBar(number) {
    let percent = "%".repeat(number/10);
    let dots = ".".repeat(10-number/10);
    let output = number.toString()+"% ["+percent+dots+"]";
    if(dots.length>0){
    console.log(output);
    console.log("Still loading...");
    }
    else{
        console.log("100% Complete!");
        console.log(output);
    }
}