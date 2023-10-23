function addItem() {
  let itemToAdd = document.getElementById("newItemText");
  let list = (document.getElementById("items"));
  let item = document.createElement("li");
  item.textContent=itemToAdd.value;
  list.appendChild(item);
  itemToAdd.textContent='';
}