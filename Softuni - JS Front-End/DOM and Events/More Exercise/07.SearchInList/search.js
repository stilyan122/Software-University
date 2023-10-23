function search() {
   const entries = Array.from(document.getElementById('towns').getElementsByTagName('li'));
   const result = document.getElementById('result');
   const input = document.getElementById('searchText').value;
   let matches = 0;
   entries.forEach((li)=>{
      li.style.fontWeight='normal';
      li.style.textDecoration='none';
      if(li.textContent.includes(input)){
         li.style.fontWeight='bolder';
         li.style.textDecoration='underline';
         matches++;
      }
   });
   result.textContent+=`${matches} matches found`;
}
