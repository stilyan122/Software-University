function addItem() {
    const text = document.getElementById('newItemText');
    const value = document.getElementById('newItemValue');
    const list = document.getElementById('menu');
    const option = document.createElement('option');
    option.value = value.value;
    option.textContent = text.value;
    list.appendChild(option);
    text.value = '';
    value.value = '';
}