function summing(number) {
    let sum=0;
    let text=number.toString();
    for (const number of text) {
        sum+=parseInt(number);
    }
    console.log(sum);
}