function city(obj) {
    let keys = Object.keys(obj);
    let values = Object.values(obj);
    for (let index = 0; index < keys.length; index++) {
       console.log(keys[index]+" -> "+values[index]);
    }
}