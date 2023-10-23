function create(words) {
   let container = document.getElementById("content");
   let array = words.toString().split(",");
   for (let index = 0; index < array.length; index++) {
      let div = document.createElement("div");
      let p = document.createElement("p");
      p.textContent='Section ' + words[index];
      p.style.display = "none";
      div.appendChild(p);
      function click() {
         p.style.display="inline";
      }
      div.addEventListener("click", click);
      container.appendChild(div);
   }
}