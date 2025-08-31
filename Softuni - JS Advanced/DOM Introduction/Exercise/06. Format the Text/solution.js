function solve() {
  let inputField = document.getElementById('input');
  let outputField = document.getElementById('output');
  let sentences = inputField.value
    .split('. ')
    .filter(s => s.length >= 1);

  let remainderSentences = sentences.length % 3; 
  let paragraphsCount = (sentences.length - remainderSentences) / 3;

  for (let i = 0; i < paragraphsCount; i++) {
    let currentSentences = sentences.splice(0, 3);
    let paragraphElement = document.createElement('p');
    paragraphElement.textContent = currentSentences.join('. ');
    outputField.appendChild(paragraphElement);
  }

  if (sentences.length > 0) {
    let remainderParagraphElement = document.createElement('p');
    let remainderSentences = sentences.splice(0);
    remainderParagraphElement.textContent = remainderSentences.join('. ');
    outputField.appendChild(remainderParagraphElement);
  }
}