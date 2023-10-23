function dna(num) {
    let pattern = "ATCGTTAGGG";
    let starsCount;
    let counter = 1;
    for (let index = 0; index < num; index++) {
        let symbol;
        if (index%4==0) {
           starsCount=2; 
        }
        else if (index%2==1) {
            starsCount=1;
        }
        else{
            starsCount=0;
        }
        let stars1 = "*".repeat(starsCount);
        let stars2 = "*".repeat(starsCount);
        if (counter==1) {
            symbol="AT";
            counter++;
        }
        else if (counter==2) {
            symbol="CG";
            counter++;
        }
        else if (counter==3) {
            symbol="TT";
            counter++;
        }
        else if (counter==4) {
            symbol="AG";
            counter++;
        }
        else if (counter==5) {
            symbol="GG";
            counter=1;
        }
        if (starsCount==2) {
            console.log(stars1+symbol+stars2);
        }
        else if (starsCount==1) {
            console.log(stars1+symbol[0]+"--"+symbol[1]+stars2);
        }
        else{
            console.log(symbol[0]+"----"+symbol[1]);
        }
    }
}