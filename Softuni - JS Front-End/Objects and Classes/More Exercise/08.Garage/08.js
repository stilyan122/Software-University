function cars(input) {
    class Garage {
        constructor(number){
            this.number = number,
            this.cars = []
        }
    }
    let garages = [];
    for (const carInfo of input) {
        const number = carInfo.split(' - ')[0];
        const info = carInfo.split(' - ')[1];
        let car = {};
        for (const entry of info.split(', ')) {
            car[entry.split(': ')[0]] = entry.split(': ')[1];
        }
        if(garages.find((garage) => garage.number === number)===undefined){
            const garage = new Garage(number);
            garage.cars.push(car);
            garages.push(garage);
        }
        else{
            garages.find((garage) => garage.number === number).cars.push(car);
        }
    }
    garages.sort((a,b) => a.number - b.number).forEach((garage) => {
      console.log(`Garage № ${garage.number}`);
      garage.cars.forEach((car)=>{
        console.log(`--- ${(Object.entries(car).map((element)=>{
            return element[0]+' - '+element[1];
        })).join(', ')}`);
      })
    });
}