function deleteByEmail() {
    let table = document.getElementById('customers');
    let output = document.getElementById('result');

    let emailInputField = document.querySelector('input[name="email"]'); 
    let email = emailInputField.value;
    let tableBody = table.getElementsByTagName('tbody')[0];
    let tableRows = Array.from(tableBody.children);

    for (let i = 0; i < tableRows.length; i++) {
        let currentRow = tableRows[i];
        let cells = Array.from(currentRow.children);

        if(cells.some(c => c.textContent === email))
        {
            tableBody.removeChild(currentRow);
            output.textContent = 'Deleted.';
            emailInputField.value = '';
            return;
        }
    }

    output.textContent = 'Not found.';
}