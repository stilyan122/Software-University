function pascal(word) {
let result = [];
let start = 0;
for (let i = 1; i < word.length; i++) {
  if (word[i] === word[i].toUpperCase()) {
    result.push(word.substring(start, i));
    start = i;
  }
}
result.push(word.substring(start)); 
console.log(result.join(', '));
}