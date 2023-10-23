function words(text) {
 let array = text.split(/\W+/)
 .map(t=>t.toUpperCase())
 .filter(x=>x!='');
 console.log(array.join(', '));
}