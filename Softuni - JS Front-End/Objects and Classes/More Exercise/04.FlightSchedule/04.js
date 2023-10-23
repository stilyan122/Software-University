function flights(input) {
    const flightsInput = input[0];
    const change = input[1];
    const status = input[2][0];
    let flights = [];
    class Flight{
        constructor(name,dest){
            this.name = name;
            this.destination = dest,
            this.changed = false
        }
    }
    for (const flight of flightsInput) {
        const name = flight.split(' ')[0];
        const destination = flight.split(' ').slice(1,flight.length).join(' ');
        const instance = new Flight(name,destination);
        flights.push(instance);
    }
    for (const flight of change) {
        const name = flight.split(' ')[0];
        const check = flights.find((fl)=>fl.name===name);
        if(check!==undefined)
        check.changed = true;
    }
    if (status==='Ready to fly') {
        flights.forEach((fl)=>{
            if(fl.changed===false){
                console.log(`{ Destination: '${fl.destination}', Status: 'Ready to fly' }`);
            }
        }
        )
    }
    else{
        flights.forEach((fl)=>{
            if(fl.changed===true){
                console.log(`{ Destination: '${fl.destination}', Status: 'Cancelled' }`);
            }
        }
        )
    }
}