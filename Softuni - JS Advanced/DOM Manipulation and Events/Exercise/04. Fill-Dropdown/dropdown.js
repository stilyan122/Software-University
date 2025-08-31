function addItem() {
    let textField = document.getElementById('newItemText');
    let valueField = document.getElementById('newItemValue');
    let menu = document.getElementById('menu');

    let text = textField.value;
    let value = valueField.value;

    let option = document.createElement('option');
    option.textContent = text;
    option.value = value;

    menu.appendChild(option);
    textField.value = '';
    valueField.value = '';
}