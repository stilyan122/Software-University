function modern(words) {
    let array = words.split(' ');
    for (const word of array) {
        if (word[0]==="#" && word.length>1 && word.substring(1,word.length).match(/^[A-Za-z]*$/)) {
            let subs = word.substring(1,word.length);
            console.log(subs);
        }
    }
}