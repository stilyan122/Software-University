function textProcessing(text,word) {
let replaceValue = "*".repeat(word.length);
while(text.includes(word)){
text=text.replace(word,replaceValue);
}
console.log(text);
}