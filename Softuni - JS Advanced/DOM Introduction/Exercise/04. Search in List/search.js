function search() {
   
   function clearStyle(towns){
      towns.forEach(town => {
         town.style.textDecoration = 'none';
         town.style.fontWeight = 'normal';
      });
   }
   
   function setStyle(towns, searchValue) {
      let matchedElements = 0;
   
      towns.forEach(townElement => {
         let town = townElement.textContent;
         if (town.toLowerCase().includes(searchValue.toLowerCase())) {
            townElement.style.textDecoration = 'underline';
            townElement.style.fontWeight = 'bold';
            matchedElements++;
         }
      });
   
      return matchedElements;
   }

   let townsList = document.getElementById('towns');
   let towns = Array.from(townsList.children);
   let searchValue = document.getElementById('searchText').value;
   let resultField = document.getElementById('result');

   clearStyle(towns);
   let matches = setStyle(towns, searchValue);
   resultField.textContent = `${matches} matches found`;
}