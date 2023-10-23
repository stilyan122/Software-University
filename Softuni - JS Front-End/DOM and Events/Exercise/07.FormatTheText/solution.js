function solve() {
  let input = document.getElementById('input').value;
  let output = document.getElementById('output');

  let str = input.split('.').filter((p) => p.length > 0);

  for (let i = 0; i < str.length; i += 3) {
      let arr = [];
      for (let y = 0; y < 3; y++) {
          if (str[i + y]) {
              arr.push(str[i + y]);
          }
      }
      let paragraph = arr.join('. ') + '.';
      output.innerHTML += `<p>${paragraph}</p>`;
  }
}