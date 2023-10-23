function printingMatrix(n) {
    for (let index = 0; index < n; index++) {
        let row = "";
        for (let index2 = 0; index2 < n; index2++) {
         row+=n.toString()+" ";
        }
        console.log(row);
    }
}