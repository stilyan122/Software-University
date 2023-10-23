function login(input) {
    let array = input.toString().split(',');
    let blocked = false;
    let username = array[0];
    let password = [...username].reverse().join("");
    let counter = 1;
    let curr = array[counter];
    while (curr!=password) {
        if (curr==password) {
            break;   
           }
        if (counter===4) {
            blocked=true;
            break;
        }
        console.log("Incorrect password. Try again.");
        counter++;
        curr=array[counter];
    }
    if (blocked==true) {
        console.log("User "+username+" blocked!" );
    }
    else{
        console.log("User "+username+" logged in.");}
    }