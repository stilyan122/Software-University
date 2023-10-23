function addItem() {
    let itemToAdd = document.getElementById("newItemText");
    let list = (document.getElementById("items"));
    let item = document.createElement("li");
    let a = document.createElement("a");
    a.href="#";
    a.textContent="[Delete]";
    a.addEventListener("click",deleteContent);
    function deleteContent() {
        list.removeChild(item);
    }
    item.textContent=itemToAdd.value;
    item.appendChild(a);
    list.appendChild(item);
    itemToAdd.textContent='';
  }