function army(input) {
    class Leader{
        constructor(name) {
          this.name = name,
          this.total = 0,
          this.army = [];
        }
    }
    class Army{
        constructor(name,count){
          this.name = name,
          this.count = count
        }
    }
    input.reduce((acc,curr) => {
        if(curr.includes('arrives')){
            const leader = new Leader(curr.split(' ').slice(0,curr.split(' ').length-1).join(' '));
            acc.push(leader);
        }
        else if(curr.includes('defeated') && acc.find((leader)=>leader.name===curr.split(' ').slice(0,curr.split(' ').length-1).join(' '))!==undefined){
            const index = acc.indexOf(acc.find((leader)=>leader.name===curr.split(' ').slice(0,curr.split(' ').length-1).join(' ')));
            acc.splice(index,1);
        }
        else if(curr.includes(':') && acc.find((leader)=>leader.name===curr.split(':')[0])!==undefined){
            const armyInfo = curr.split(': ')[1];
            const name = armyInfo.split(', ')[0];
            const count = Number(armyInfo.split(', ')[1]);
            const army = new Army(name,count);
            acc.find((leader)=>leader.name===curr.split(':')[0]).army.push(army);
            acc.find((leader)=>leader.name===curr.split(':')[0]).total+=army.count;
        }
        else if(curr.includes('+') &&  acc.find((leader)=>leader.army.find((army)=>army.name===curr.split(' + ')[0]))!==undefined){
            acc.find((leader)=>leader.army.find((army)=>army.name===curr.split(' + ')[0]))
            .army.find((army)=>army.name===curr.split(' + ')[0]).count+=Number(curr.split(' + ')[1]);
            acc.find((leader)=>leader.army.find((army)=>army.name===curr.split(' + ')[0])).total+=Number(curr.split(' + ')[1]);
        }
        return acc;
    },[]).sort((a,b) => b.total-a.total).forEach((leader)=>{
        console.log(`${leader.name}: ${leader.total}`);
        leader.army.sort((a,b) => b.count-a.count).forEach((army)=>{
            console.log(`>>> ${army.name} - ${army.count}`);
        });
    })
}