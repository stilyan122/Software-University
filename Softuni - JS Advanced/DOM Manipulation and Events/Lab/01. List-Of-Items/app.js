function addItem() {
    let inputField = document.getElementById('newItemText');
    let textToAppend = inputField.value;

    let list = document.getElementById('items');
    let child = document.createElement('li');

    child.textContent = textToAppend;
    list.appendChild(child);
    inputField.value = '';
}