function extractText() {
   let items = Array.from(document.getElementById('items').children);
   let result = document.getElementById('result'); 
   items.forEach((child) => {
    result.textContent += child.textContent + '\n';
   });
}