function address(input) {
    let array = input.toString().split(",");
    let output = {};
    for (let index = 0; index < array.length; index++) {
        let split = array[index].toString().split(':');
        output[split[0]]=split[1];
    }
    const arr = Object.entries(output);
    arr.sort((a, b) => a[0].localeCompare(b[0]));
    const sorted = Object.fromEntries(arr);
    for (const el in sorted) {
        console.log(el+" -> "+sorted[el]);
    }
}