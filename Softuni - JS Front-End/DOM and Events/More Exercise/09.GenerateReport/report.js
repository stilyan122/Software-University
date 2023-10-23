function generateReport() {
    const output = document.getElementById('output');
    const thead = document.querySelector('table > thead > tr').getElementsByTagName('th');
    let checked = {};
    let outputArr = [];
    for (let index = 0; index < thead.length; index++) {
        const element = thead[index].getElementsByTagName('input')[0];
        if(element.checked){
            checked[index] = element.name.trim(); 
        }
    }
    const tbody = document.querySelector('table > tbody').getElementsByTagName('tr');
    for (const row of tbody) {
        const cols = row.getElementsByTagName('td');
        let obj = {};
        for (let index = 0; index < cols.length; index++) {
            const element = cols[index];
            if(checked.hasOwnProperty(index)){
                obj[checked[index]] = element.textContent;
            }
        }
        outputArr.push(obj);
    }
    output.textContent+=JSON.stringify(outputArr,null,2);
}