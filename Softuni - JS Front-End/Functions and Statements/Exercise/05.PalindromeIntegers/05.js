function palindrome(arr) {
    let array = arr.toString().split(",");
    for (let index = 0; index < array.length; index++) {
        let current = array[index].toString().split("");
        if (current.toString()===current.reverse().toString()) {
            console.log("true");
        }
        else{
            console.log("false");
        }
    }
}