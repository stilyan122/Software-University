function passValidator(password) {
    let isValid=true;
    if (!(password.length>=6 && password.length<=10)) {
        console.log("Password must be between 6 and 10 characters");
        isValid=false;
    }
    if (!(password.match(/^[A-Za-z0-9]*$/))) {
        console.log("Password must consist only of letters and digits");
        isValid=false;
    }
    if (!(password.match(/\w*\d{2,}\w*/))) {
        console.log("Password must have at least 2 digits");
        isValid=false;
    }
    if (isValid===true) {
        console.log("Password is valid");
    }
}