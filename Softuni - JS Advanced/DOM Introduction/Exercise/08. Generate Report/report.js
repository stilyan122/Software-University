function generateReport() {
    let table = document.getElementsByTagName('table')[0];
    let tableHead = table.getElementsByTagName('thead')[0];
    let tableHeadRow = tableHead.getElementsByTagName('tr')[0];

    let checkedTableHeadCells = Array
        .from(tableHeadRow
                .getElementsByTagName('input'))
        .map((cell, i) => ({ element: cell, index: i }))
        .filter(c => c.element.checked);
    
    let tableBody = table.getElementsByTagName('tbody')[0];
    let tableBodyRows = Array.from(tableBody.children);

    let outputArray = [];

    tableBodyRows.forEach(tbr => {
        let currentRowCells = Array.from(tbr.children)
            .filter((child, i) => checkedTableHeadCells.some(headCell => 
                headCell.index === i
            ))
            .map(c => c.textContent);

        let obj = {};

        for (let i = 0; i < checkedTableHeadCells.length; i++) {
            obj[checkedTableHeadCells[i].element.name] = currentRowCells[i];
        }

        outputArray.push(obj);
    });

    let outputField = document.getElementById('output');
    outputField.value = JSON.stringify(outputArray, null, 2);
}