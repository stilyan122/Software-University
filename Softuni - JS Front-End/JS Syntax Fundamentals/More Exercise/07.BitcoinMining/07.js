function mining(input) {
    let array = input.toString().split(",");
    let firstBitcoin = 0;
    let days = 0;
    let sum = 0;
    let bitcoins = 0;
    for (let index = 0; index < array.length; index++) {
        days++;
        if (days%3===0) {
            sum+= (array[index]-0.30*array[index])*67.51;
        }
        else{
        sum += array[index]*67.51;
        }
        if (sum>=11949.16) {
            while(sum>=11949.16){
                if (bitcoins===1 && firstBitcoin===0 ) {
                    firstBitcoin=days;
                }
            sum-=11949.16;
            bitcoins++;
            }
        }
        if (bitcoins===1 && firstBitcoin===0 ) {
            firstBitcoin=days;
        }
    }
    console.log(`Bought bitcoins: ${bitcoins}`);
    if(bitcoins>0){
    console.log(`Day of the first purchased bitcoin: ${firstBitcoin}`);
    }
    console.log(`Left money: ${sum.toFixed(2)} lv.`)
}