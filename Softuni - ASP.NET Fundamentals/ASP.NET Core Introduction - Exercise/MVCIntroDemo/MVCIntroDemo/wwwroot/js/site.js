function GetNumbers() {
    var input = document.getElementsByName("numberInput")[0].value;

    window.location = "https://localhost:7224/home/numberston?count=" + input;
}