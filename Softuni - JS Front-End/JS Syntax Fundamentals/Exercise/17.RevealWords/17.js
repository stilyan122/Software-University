function revealingWords(words ,text) {
    let wordsSplit = words.split(', ');
    let textSplit = text.split(" ");
    for (const wordToReplace of wordsSplit) {
        for (let index = 0; index < textSplit.length; index++) {
            let currentElement = textSplit[index];
           if (wordToReplace.length===currentElement.length && currentElement==="*".repeat(wordToReplace.length)) {
           text = text.replace(currentElement, wordToReplace);
           textSplit=text.split(" ");
           }
        }
    }
 console.log(textSplit.join(' '));
}