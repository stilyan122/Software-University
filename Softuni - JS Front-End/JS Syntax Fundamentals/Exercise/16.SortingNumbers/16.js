function sorting(array) {
    let output = [];
    let counter = 0;
    while (array.length>0) {
        let index2 = array.indexOf(Math.min(...array));
        output[counter] = array[index2];
        array.splice(index2,1);
        counter++;
        let index = array.indexOf(Math.max(...array));
        output[counter] = array[index];
        array.splice(index,1);
        counter++;
    }
    return output;
}