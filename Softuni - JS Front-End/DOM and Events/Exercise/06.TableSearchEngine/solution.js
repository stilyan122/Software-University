function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const actives = Array.from(document.getElementsByClassName('select'));
      console.log(actives);
      for (const active of actives) {
         active.classList.remove('select');
      }
      const field = document.getElementById('searchField');
      const value = field.value;
      field.value='';
      const table = document.getElementsByClassName('container')[0];
      const body = table.getElementsByTagName('tbody')[0];
      const rows = body.getElementsByTagName('tr');
      for (const row of rows) {
         const cols = row.getElementsByTagName('td');
         for (const col of cols) {
            if(col.textContent.includes(value)){
               row.classList.add('select');
               console.log(col);
               break;
            }
         }
      }
   }
}