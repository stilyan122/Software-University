function extract(content) {
  const text = document.getElementById(content).textContent;
  let output = [];
  const regex = new RegExp(/\((.+?)\)/g);
  let match = regex.exec(text);
  while (match!=null) {
    output.push(match[1]);
    match=regex.exec(text);
  }
  return output.join('; ');
}