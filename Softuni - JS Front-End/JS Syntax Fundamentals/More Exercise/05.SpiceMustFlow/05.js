function mining(start) {
    let mine = 0;
    let days=0;
    while (start>=100) {
        days++;
        if(start>26){
        mine+=start-26;
        }
        start-=10;
    }
    if(mine>26){
    mine-=26;
    }
    console.log(days);
    console.log(mine);
}