function deleteByEmail() {
    let table = document.getElementById("customers");
    let body = table.getElementsByTagName("tbody")[0];
    let rows = Array.from(body.getElementsByTagName("tr"));
    let input = document.getElementsByName("email");
    let found = false;
    let output = document.getElementById("result");
    for (const row of rows) {
        let tds = Array.from(row.getElementsByTagName("td"));
        if (tds[1].textContent==input[0].value) {
            body.removeChild(row);
            output.textContent="Deleted.";
            found = true;
            break;
        }
    }
    if (found==false) {
        output.textContent="Not found.";
    }
    input.value='';
}