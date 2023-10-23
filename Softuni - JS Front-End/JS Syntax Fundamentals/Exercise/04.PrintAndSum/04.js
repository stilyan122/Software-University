function numbers(start,end) {
    let array = [];
    let counter =0;
    let sum=0;
    for (let index = start; index <= end; index++) {
      array[counter]=index;
      sum+=array[counter];
      counter++;
    }
    console.log(array.join(' '));
    console.log("Sum: "+sum);
}