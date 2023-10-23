function inventory(input) {
    class Hero{
        constructor(name,level,items){
            this.name=name;
            this.level=level;
            this.items=items;
        }
    }
    let heroes = [];
    for (const command of input) {
        const split = command.split(' / ');
        const hero = new Hero(split[0],split[1],split[2]);
        heroes.push(hero);
    }
    heroes.sort((a,b) => a.level-b.level).forEach(hero=>
        {
            console.log(`Hero: ${hero.name}`);
            console.log(`level => ${hero.level}`);
            console.log(`items => ${hero.items}`);
        })
}