   function loadRepos() {
   const output = document.getElementById("res");
   const URL = "https://api.github.com/users/testnakov/repos";
   fetch(URL)
   .then(res=> res.text())
   .then(data=>
   {
      output.textContent=data;
      console.log(data);
   });
}