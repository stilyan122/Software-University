function getInfo() {
    const id = document.getElementById('stopId').value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/`+id;
    const stopName = document.getElementById('stopName');
    const buses = document.getElementById('buses');
    const response = fetch(url)
    .then((res)=>{
        res.json()
        .then((json)=>{
            const stop = json.name;
            stopName.textContent = stop;
            const busesObj = json.buses;
            const entries = Object.entries(busesObj);
            entries.forEach((entry)=>{
                const li = document.createElement('li');
                li.textContent+=`Bus ${entry[0]} arrives in ${entry[1]} minutes`;
                buses.appendChild(li);
            });
        })
        .catch(()=>{
            stopName.textContent = 'Error';
        });
    })
    .catch(()=>{
        stopName.textContent = 'Error';
    });
}