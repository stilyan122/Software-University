function solve() {
  const text = document.getElementById('text').value;
  const transformation = document.getElementById('naming-convention').value;
  const output = document.getElementById('result');
  let transformedText = "";
  switch (transformation) {
    case 'Camel Case':
    text.split(' ').forEach((word)=>{
       word = word[0].toUpperCase()+word.substring(1,word.length).toLowerCase();
       transformedText+=word;
    });
    transformedText = transformedText[0].toLowerCase()+transformedText.substring(1,transformedText.length);
    break;
  
    case 'Pascal Case':
      text.split(' ').forEach((word)=>{
        word = word[0].toUpperCase()+word.substring(1,word.length).toLowerCase();
        transformedText+=word;
     });
    break;

    default:
     transformedText="Error!";
      break;
  }
  output.textContent=transformedText;
}