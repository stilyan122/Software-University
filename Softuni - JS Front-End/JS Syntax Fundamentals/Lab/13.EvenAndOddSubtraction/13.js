function arrayManipulation(array) {
    let even=0;
    let odd=0;
    for (let index = 0; index < array.length; index++) {
       if (array[index]%2===0) {
        even+=array[index];
       }
       else{
        odd+=array[index];
       }
    }
    console.log(even-odd);
}