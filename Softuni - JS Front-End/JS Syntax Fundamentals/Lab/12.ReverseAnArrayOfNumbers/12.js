function arrayManipulation(n,array) {
   let arrayNew = new Array;
   for (let index = 0; index < n; index++) {
    arrayNew[index]=array[index];
   }
   arrayNew.reverse();
   console.log(arrayNew.join(" "));
}