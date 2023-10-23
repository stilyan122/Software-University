function summing(number) {
    let text = number.toString();
    let isEven=true;
    let sum=0;
    for (let index = 0; index < text.length-1; index++) {
       let last = text[index];
       if(last===text[index+1]){
         last=text[index+1];
       }
       else if(isEven===true){
        console.log("false");
        isEven=false;
       }
       sum+=parseInt(text[index]);
    }
    sum+=parseInt(text[text.length-1]);
    if (isEven===true) {
        console.log("true");
    }
    console.log(sum);
}