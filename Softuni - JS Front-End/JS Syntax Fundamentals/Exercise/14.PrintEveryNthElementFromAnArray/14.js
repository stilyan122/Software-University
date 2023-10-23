function stepping(array,steps) {
    let arr=array.slice(',');
    let arrayOutput=[];
    let counter=0;
    for (let index = 0; index < array.length; index+=steps) {
       arrayOutput[counter]=arr[index];
       counter++;
    }
    return arrayOutput;
}