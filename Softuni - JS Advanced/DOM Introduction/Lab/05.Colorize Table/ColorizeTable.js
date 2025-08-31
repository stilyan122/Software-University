function colorize() {
    let table = document.getElementsByTagName('tbody')[0];

    let rows = Array.from(table.children).filter((element, index) => index % 2 == 1);
    
    rows.forEach((row) => {
        row.style.backgroundColor = "Teal";
    });
}