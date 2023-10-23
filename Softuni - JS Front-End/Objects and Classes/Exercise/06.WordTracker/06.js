function occurences(input) {
    const words = input[0];
    let occurences = {};
    for (const word of words.split(' ')) {
        occurences[word] = 0;
    }
    for (let index = 1; index < input.length; index++){
        const element = input[index];
        if (occurences.hasOwnProperty(element)){
            occurences[element]++;
        }
    }
    Object.entries(occurences).sort((a,b) => b[1]-a[1]).forEach((word)=>{
        console.log(`${word[0]} - ${word[1]}`)
    });
}