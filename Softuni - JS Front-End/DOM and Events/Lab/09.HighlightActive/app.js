function focused() {
    let divs = document.querySelectorAll("div div")
    for (const div of divs) {
      let input = div.querySelector("input");
      input.addEventListener('focus',clicked);
      input.addEventListener('blur',blured);
      function clicked() {
        div.className="focused";
    }
    function blured() {
        div.classList.remove("focused");
    
    }}
}