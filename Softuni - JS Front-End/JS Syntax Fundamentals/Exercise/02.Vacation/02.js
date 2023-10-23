function priceCalculation(count,type,day) {
    let price=0;
    let reduce=0;
    if (type==="Students" && count>=30) {
       reduce=0.15;
    }
    if (type==="Business" && count>=100) {
       count-=10;
    }
    if (type==="Regular" && count>=10 && count<=20) {
        reduce=0.05;
    }
    switch (type) {
        case "Students":
          switch (day) {
            case "Friday":
            price=8.45; 
            break;
            case "Saturday":
            price=9.80;
            break;
            case "Sunday":
            price=10.46;
            break;
        }  
        break;
        case "Business":
            switch (day) {
              case "Friday":
                 price=10.90;
              break;
              case "Saturday":
                 price=15.60;
              break;
              case "Sunday":
                  price=16.00;
              break;
          }  
        break;
        case "Regular":
          switch (day) {
            case "Friday":
                price=15.00;
            break;
            case "Saturday":
                price=20.00;
            break;
            case "Sunday":
                price=22.50;
            break;
        }  
        break;
    }
    price*=count;
    price-=price*reduce;
    console.log(`Total price: ${price.toFixed(2)}`);
}