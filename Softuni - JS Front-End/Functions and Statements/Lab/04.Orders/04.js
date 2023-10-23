function returningPrice(product,count) {
    let result = count;
    switch (product) {
        case "coffee":
           result*=1.50; 
        break;
        case "water":
           result*=1.00; 
        break;
        case "coke":
           result*=1.40; 
        break;
        case "snacks":
           result*=2.00; 
        break;
    }
    console.log(result.toFixed(2));
}