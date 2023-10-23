function occurences(input) {
    let occurences = new Map();
    let output = [];
    for (let firstWord of input.split(' ')) {
        let count = 0;
        for (let secondWord of input.split(' ')) {
            if (firstWord.toLowerCase() === secondWord.toLowerCase()) {
                count++
            }
        }
        occurences.set(firstWord.toLowerCase(), count)
    }
    let filter = Array.from(occurences.entries()).filter(([word, count]) => count % 2 == 1);
    for (let [word, num] of filter) {
        output.push(word)
    } 
    console.log(output.join(' ').toString());
}