function search(text,word) {
    let counter=0;
    let array = text.split(' ');
    for (const item of array) {
        if (item===word) {
           counter++; 
        }
    }
    console.log(counter);
}