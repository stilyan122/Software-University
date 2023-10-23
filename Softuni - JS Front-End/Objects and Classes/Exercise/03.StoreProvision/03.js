function store(input1,input2) {
    let array1 = input1.toString().split(',');
    let array2 = input2.toString().split(',');
    let output = {};
    for (let index = 0; index < array1.length; index+=2) {
        let name = array1[index];
        let quantity = Number(array1[index+1]);
        if (typeof(output[name])!="undefined") {
            output[name]+=quantity;
        }
        else{
            output[name]=quantity;
        }
    }
    for (let index = 0; index < array2.length; index+=2) {
        let name = array2[index];
        let quantity = Number(array2[index+1]);
        if (typeof(output[name])!="undefined") {
            output[name]+=quantity;
        }
        else{
            output[name]=quantity;
        }
    }
    for (const key in output) {
       console.log(key+" -> "+output[key]);
    }
}