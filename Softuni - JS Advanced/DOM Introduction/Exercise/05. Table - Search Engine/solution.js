function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function clearRows(rows) {
      rows.forEach(row => {
         row.classList.remove('select');
      });
   }

   function onClick() {
      let table = document.getElementsByClassName('container')[0];
      let tableBody = table.getElementsByTagName('tbody')[0];
      let searchField = document.getElementById('searchField');
      let searchValue = searchField.value;

      let rows = Array.from(tableBody.children);
      clearRows(rows);

      rows.forEach(row => {
         let cells = Array.from(row.children);

         cells.forEach(cell => {
            if (cell.textContent.includes(searchValue)) {
               row.classList.add('select');
            }
         });
      });
   }
}