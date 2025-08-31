function solve() {
  let textField = document.getElementById('text');
  let conventionField = document.getElementById('naming-convention');

  let textValue = textField.value;
  let conventionValue = conventionField.value;

  let resultField = document.getElementById('result');
  let textSplitted = textValue.split(' ');
  let result = '';

  if (conventionValue === 'Pascal Case') {
    textSplitted.forEach(text => {
      result += text[0].toUpperCase() + text.slice(1).toLowerCase();
    });
  } else if (conventionValue === 'Camel Case') {
    let deletedText = textSplitted.splice(0, 1)[0];
    result += deletedText[0].toLowerCase() + deletedText.slice(1).toLowerCase();

    textSplitted.forEach(text => {
      result += text[0].toUpperCase() + text.slice(1).toLowerCase();
    });
  } else{
    result = 'Error!';
  }

  resultField.textContent = result;
}