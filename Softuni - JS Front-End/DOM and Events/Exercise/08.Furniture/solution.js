function solve() {
 const result = document.getElementsByTagName('textarea')[1];
 result.disabled = false;
 const body = document.getElementsByClassName('table')[0].getElementsByTagName('tbody')[0];
 const button1 = document.getElementById('exercise').getElementsByTagName('button')[0];
 button1.addEventListener('click',function(){
  let obj = document.getElementById('exercise').getElementsByTagName('textarea')[0];
  const json = JSON.parse(obj.value);
   for (const data of json) {
   const row = document.createElement('tr');
   body.appendChild(row);
   const imageCell = document.createElement('td');
   const img = document.createElement('img');
   img.src=data['img'];
   imageCell.appendChild(img);
   const name = document.createElement('td');
   name.textContent=data['name'];
   const price = document.createElement('td');
   price.textContent=data['price'];
   const factor = document.createElement('td');
   factor.textContent=data['decFactor'];
   const checkboxCell = document.createElement('td');
   const check = document.createElement('input');
   check.type='checkbox';
   checkboxCell.appendChild(check);
   row.appendChild(imageCell);
   row.appendChild(name);
   row.appendChild(price);
   row.appendChild(factor);
   row.appendChild(checkboxCell); 
   }
 });
 const button2 = document.getElementById('exercise').getElementsByTagName('button')[1];
 button2.addEventListener('click',function() {
    let names = [];
    let totalPrice = 0.0;
    let sum = 0.0;
    let count = 0.0;
    const rows = Array.from(body.getElementsByTagName('tr'));
    for (const row of rows) {
        const cols = Array.from(row.getElementsByTagName('td'));
        const check = cols[4].getElementsByTagName('input')[0];
        console.log(1);
        if(check.checked){
            names.push(cols[1].textContent);
            totalPrice+=Number(cols[2].textContent);
            count++;
            sum+=Number(cols[3].textContent);
        }
    }
    console.log(names);
    result.textContent+=`Bought furniture: ${names.join(', ')}\n`;
    result.textContent+=`Total price: ${totalPrice.toFixed(2)}\n`;
    result.textContent+=`Average decoration factor: ${sum/count}`;
 })
}