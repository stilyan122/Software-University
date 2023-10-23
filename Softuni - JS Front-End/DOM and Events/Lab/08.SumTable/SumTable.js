function sumTable() {
let table = document.getElementsByTagName("table")[0];
let tds = table.getElementsByTagName("td");
let output = document.getElementById("sum");
output.textContent='';
let sum = 0;
for (const td of tds) {
    if (isNaN(td.textContent)==false) {
        sum+=Number(td.textContent);
    }
}
output.textContent=sum;
}