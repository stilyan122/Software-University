function cooking(nums,...operations) {
    let array = operations;
    let num = parseInt(nums);
    for (const op of array) {
        switch (op) {
            case "chop":
            num/=2;
            break;
            case "dice":
            num=Math.sqrt(num);
            break;
            case "spice":
            num+=1;
            break;
            case "bake":
            num*=3;
            break;
            case "fillet":
            num-=0.20*num;
            break;
            default:
                break;
        }
        console.log(num);
    }
}