function employees(input) {
   let array = input.toString().split(',');
   let output = [];
   for (let index = 0; index < array.length; index++) {
    let num = array[index].length;
    output[index] = "Name: "+array[index]+" -- Personal Number: "+num; 
   } 
   output.forEach(t=>console.log(t));
}