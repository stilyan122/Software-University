function convert(json) {
    let obj = JSON.parse(json);
    let keys = Object.keys(obj);
    let values = Object.values(obj);
    for (let index = 0; index < keys.length; index++) {
        console.log(keys[index]+": "+values[index]);
    }
}