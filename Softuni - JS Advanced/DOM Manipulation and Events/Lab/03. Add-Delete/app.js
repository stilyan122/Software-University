function addItem() {
    let inputField = document.getElementById('newItemText');
    let textToAppend = inputField.value;

    let list = document.getElementById('items');
    let child = document.createElement('li');

    child.textContent = textToAppend;

    let deleteLink = document.createElement('a');
    deleteLink.href = '#';
    deleteLink.textContent = '[Delete]';

    deleteLink.addEventListener('click', function(_) {
        list.removeChild(child);
    });

    child.appendChild(deleteLink);
    list.appendChild(child);
    inputField.value = '';
}