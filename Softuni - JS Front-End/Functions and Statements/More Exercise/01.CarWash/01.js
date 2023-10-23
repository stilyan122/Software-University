function carWash(input) {
    let commands = input.toString().split(',');
    let value = 0;
    for (const command of commands) {
        switch (command) {
            case 'soap':
                value+=10;
            break;
            case 'water':
                value+=0.20*value;
            break;
            case 'vacuum cleaner':
                value+=0.25*value;
            break;
            case 'mud':
                value-=0.10*value;
            break;
        }
    }
    console.log(`The car is ${value.toFixed(2)}% clean.`);
}