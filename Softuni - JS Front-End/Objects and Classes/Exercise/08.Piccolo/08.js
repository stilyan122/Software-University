function picolo(input) {
    let cars = [];
    class Car{
        constructor(num){
            this.number=num;
        }
    }
    for (const command of input) {
        const type = command.toString().split(', ')[0];
        const number = command.toString().split(', ')[1];
        const check = cars.find((car)=>car.number===number);
        const car = new Car(number);
        if(type==='IN' && check===undefined){
            cars.push(car);
        }
        else if(type==='OUT'){
            const car = cars.find((car)=>car.number===number);
            if(car!==undefined){
                const index = cars.indexOf(car);
                cars.splice(index,1);
            }
        }
    }
    if(cars.length===0){
        console.log("Parking Lot is Empty");
    }
    else{
        cars.sort((a,b)=>a.number.localeCompare(b.number)).forEach(
            (car) => {
                console.log(car.number);
            }
        );
    }
}