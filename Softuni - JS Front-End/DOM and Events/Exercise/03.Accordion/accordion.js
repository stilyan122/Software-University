function toggle() {
    let button = document.getElementsByClassName("button")[0];
    let info = document.getElementById("extra");
    if (button.textContent==='More') {
        info.style.display="block";
        button.textContent="Less";
    }
    else{
        button.textContent="More";
        info.style.display="none";
    }
}