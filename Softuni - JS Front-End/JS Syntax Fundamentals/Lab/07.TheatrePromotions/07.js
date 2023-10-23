function findTicketPrice(day,age) {
  let output;
  if (age>=0&&age<=18) {
    switch (day) {
        case "Weekday":
            output="12$";
        break;
        case "Weekend":
            output="15$";
        break;
        case "Holiday":
            output="5$";
        break;
    }
  }
  else if (age>18&&age<=64) {
    switch (day) {
        case "Weekday":
            output="18$";
        break;
        case "Weekend":
            output="20$";
        break;
        case "Holiday":
            output="12$";
        break;
    }
  }
  else if (age>64&&age<=122) {
    switch (day) {
        case "Weekday":
            output="12$";
        break;
        case "Weekend":
            output="15$";
        break;
        case "Holiday":
            output="10$";
        break;
    }
  }
  else{
    output="Error!";
  }
  console.log(output);
}
