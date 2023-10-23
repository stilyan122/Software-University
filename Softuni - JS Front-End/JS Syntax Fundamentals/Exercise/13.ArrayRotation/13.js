function rotationArray(array,rotations) {
    let arr = array.slice(', ');
    for (let index = 0; index < rotations; index++) {
        let element = arr.shift();
        arr.push(element);
    }
    console.log(arr.join(' '));
}