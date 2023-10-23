function towns(input) {
    let array = input.toString().split(",");
    let towns = []
    for (let index = 0; index < array.length; index++) {
        let splitTowns = array[index].toString().split(" | ");
        let town = splitTowns[0];
        let latitude = Number(splitTowns[1]).toFixed(2);
        let longitude = Number(splitTowns[2]).toFixed(2);
        let obj = {town:town, latitude:latitude,longitude:longitude};
        towns[index] = obj;
    }
    towns.forEach(element => {
     console.log(element);   
    });
}