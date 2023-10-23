function sort(input) {
    input = input.map(el => JSON.parse(el))
    .forEach(el => el.sort((a, b) => b - a));
    let output = [];
    for (let i = 0; i < input.length; i++) {
        let currentArray = input[i];
        let isUnique = true;
        for (let j = 0; j < output.length; j++) {
            let nextArray = output[j];
            if (nextArray.toString() === currentArray.toString()) {
                isUnique = false;
                break;
            }
        }
        if (isUnique) {
            output.push(currentArray);
        }
    }
    output.sort((a, b) => a.length - b.length)
    .forEach(el => console.log(`[${el.join(', ')}]`));
}