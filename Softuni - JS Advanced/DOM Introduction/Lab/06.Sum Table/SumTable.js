function sumTable() {
    let table = document.querySelector('table');
    let rows = Array.from(table.children[0].children);
    let filtered = rows.filter((element, index) => index > 0 && index < rows.length - 1);

    let sum = 0;

    filtered.forEach((row) => {
        let columns = Array.from(row.children);
        let lastColumn = columns[columns.length - 1];
        sum += parseFloat(lastColumn.textContent);
    });

    let total = document.getElementById('sum');
    total.textContent = sum;
}