function meetings(input) {
    let array = input.toString().split(",");
    let output = {};
    for (let index = 0; index < array.length; index++) {
        let split = array[index].toString().split(' ');
        if (Object.keys(output).includes(split[0])) {
            console.log("Conflict on "+split[0]+"!");
        }
        else{
        output[split[0]]=split[1];
        console.log("Scheduled for "+split[0]);
        }
    }
    for (const el in output) {
        console.log(el+" -> "+output[el]);
    }
}