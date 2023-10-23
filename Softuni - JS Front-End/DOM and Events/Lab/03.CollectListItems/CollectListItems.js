function extractText() {
    let elements = Array.from(document.getElementById("items").children);
    let textArea = document.getElementById("result");
    for (let index = 0; index < elements.length; index++) {
      textArea.appendChild(elements[index]);
    }
}