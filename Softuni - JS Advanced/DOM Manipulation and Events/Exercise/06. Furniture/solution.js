function solve() {
  let container = document.getElementById('exercise');

  let textAreaInput = container.getElementsByTagName('textarea')[0];
  let textAreaOutput = container.getElementsByTagName('textarea')[1];
  let generateButton = container.getElementsByTagName('button')[0];
  let buyButton = container.getElementsByTagName('button')[1];

  let table = document.getElementsByClassName('table')[0];
  let body = table.getElementsByTagName('tbody')[0]; 

  generateButton.addEventListener('click', function(){
    let input = JSON.parse(textAreaInput.value);

    input.forEach(obj => {
      let name = obj.name;
      let price = obj.price;
      let decoration = obj.decFactor;
      let img = obj.img;

      let tableRow = document.createElement('tr');

      let nameTd = document.createElement('td');
      nameTd.textContent = name;

      let imgTd = document.createElement('td');
      let imgElement = document.createElement('img');
      imgElement.src = img;
      imgTd.appendChild(imgElement);

      let priceTd = document.createElement('td');
      priceTd.textContent = price;

      let decorationTd = document.createElement('td');
      decorationTd.textContent = decoration;

      let checkBoxTd = document.createElement('td');
      let checkBox = document.createElement('input');
      checkBox.type = 'checkbox';
      checkBoxTd.appendChild(checkBox);

      tableRow.appendChild(imgTd);
      tableRow.appendChild(nameTd);
      tableRow.appendChild(priceTd);
      tableRow.appendChild(decorationTd);
      tableRow.appendChild(checkBoxTd);

      body.appendChild(tableRow);
    });
  });

  buyButton.addEventListener('click', function(){
    let checked = Array.from(body.getElementsByTagName('input'))
      .filter(x => x.checked);

    let names = [];
    let totalPrice = 0;
    let averageDecoration = 0;

    checked.forEach(x => {
      let row = x.parentElement.parentElement;
      let cells = row.getElementsByTagName('td');
      names.push(cells[1].textContent);
      totalPrice += Number(cells[2].textContent);
      averageDecoration += Number(cells[3].textContent);
    });

    averageDecoration = averageDecoration / checked.length;

    textAreaOutput.value = `Bought furniture: ${names.join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${averageDecoration}`;
  });
}