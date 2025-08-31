function create(words) {
   let container = document.getElementById('content');

   words.forEach(word => {
      let div = document.createElement('div');
      let p = document.createElement('p');

      p.textContent = word;
      p.style.display = 'none';

      div.addEventListener('click', function () {
         p.style.display = 'block';
      });

      div.appendChild(p);
      container.appendChild(div);
   });
}