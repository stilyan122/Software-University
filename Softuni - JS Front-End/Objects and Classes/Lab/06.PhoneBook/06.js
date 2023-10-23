function telephone(input) {
    let list = input.toString().split(",");
    let output = {};
    for (let index = 0; index < list.length; index++) {
       let split = list[index].toString().split(' ');
       output[split[0]]=split[1];
    }
    for (const key in output) {
        console.log(key+" -> "+output[key]);
    }
}   