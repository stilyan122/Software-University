function expenses(lost,helmet,sword,shield,armor) {
    let output = 0;
    let brokenShields = 0;
    for (let index = 1; index <= lost; index++) {
        let lostHelmet = false;
        let lostSword = false;
        if (index%2==0) {
            lostHelmet=true;
            output+=helmet;
        }
        if (index%3==0) {
            lostSword=true;
            output+=sword;
        }
        if (lostSword===true && lostHelmet===true) {
            brokenShields+=1;
            if (brokenShields%2==0) {
             output+=armor;
            }
            output+=shield;
        }
    }
    console.log("Gladiator expenses: "+output.toFixed(2)+" aureus");
}