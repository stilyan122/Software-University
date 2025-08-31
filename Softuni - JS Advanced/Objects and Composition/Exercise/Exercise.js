function calorieObject(input) {
    let object = {};

    for (let i = 1; i < input.length; i+=2) {
        object[input[i - 1]] = parseFloat(input[i]);
    }

    console.log(object);
}

function constructionCrew(worker) {
    if (worker['dizziness']) {
        let waterQuantity = 0.1 * worker['weight'] * worker['experience'];
        worker['levelOfHydrated'] += waterQuantity;
        worker['dizziness'] = false;
    }

    return worker;
}

function carFactory(requirements) {
    let car = {
        model: requirements['model']
    };

    let requiredPower = requirements['power'];
    let engine = {};

    if (requiredPower <= 90) {
        engine = { power: 90, volume: 1800 }
    } else if (requiredPower <= 120) {
        engine = { power: 120, volume: 2400 }
    } else{
        engine = { power: 200, volume: 3500 }
    }

    car.engine = engine;

    let requiredCarriage = requirements['carriage'];
    let requiredColor = requirements['color'];
    let carriage = { type: requiredCarriage, color: requiredColor };

    car.carriage = carriage;

    let requiredWheels = requirements['wheelsize'];
    if (requiredWheels % 2 === 0) {
        requiredWheels--;
    }

    let wheels = Array(4).fill(requiredWheels);
    car.wheels = wheels;

    return car;
}

function heroicInventory(input) {
    let heroes = [];

    input.forEach(heroInfoStr => {
        let [heroName, heroLevelStr, heroItemsStr] = heroInfoStr.split(' / ');
        let heroItems = heroItemsStr ? heroItemsStr.split(', ') : [];
        let heroLevel = parseFloat(heroLevelStr);

        let hero = {
            name: heroName,
            level: heroLevel,
            items: heroItems
        }

        if(hero.name && hero.items && hero.level){
            heroes.push(hero);
        }
    });

    let JSONOutput = JSON.stringify(heroes);

    console.log(JSONOutput);
}

function lowestPricesInCities(info) {
   let products = {};

   info.forEach(townAndProductInfo => {
        let [townName, productName, productPrice] = townAndProductInfo.split(' | ');
        productPrice = parseFloat(productPrice);

        if (products[productName]) {
            if(products[productName].price > productPrice){
                products[productName].town = townName;
                products[productName].price = productPrice;
            }
        } else{
            products[productName] = {
                name: productName,
                town: townName,
                price: productPrice
            };
        }
   });

   for (const product in products) {
    console.log(`${products[product].name} -> ${products[product].price} (${products[product].town})`);
   }
}

function storeCatalogue(products) {
    function sortObjectByKeys(obj) {
        const sortedKeys = Object.keys(obj).sort();
        const sortedObj = {};
    
        for (const key of sortedKeys) {
            sortedObj[key] = obj[key];
        }
    
        return sortedObj;
    }

    let catalogueUnsorted = {};

    products.forEach(productStr => {
        var [name, price] = productStr.split(' : ');
        var letter = name[0].toUpperCase();
        var product = { name: name, price: parseFloat(price) };
        
        if (catalogueUnsorted[letter]) {
            catalogueUnsorted[letter].push(product)
        } else {
            catalogueUnsorted[letter] = [product];
        }
    });

    let catalogueSorted = sortObjectByKeys(catalogueUnsorted);

    for (const key in catalogueSorted) {
        console.log(key);
        let sortedProducts = catalogueSorted[key]
            .sort((a, b) => a.name.localeCompare(b.name));
            
        for (const product of sortedProducts) {
            console.log(`  ${product.name}: ${product.price}`)
        }
    }
}

function townsToJSON(input) {
    let table = [];

    function removePipesAndSpaces(element) {
        if (element[0] === '|') {
            element = element.slice(1);
        } if (element[element.length - 1] === '|') {
            element = element.slice(0, element.length - 1);
        }

        return element.trim();
    }

    let propertiesRow = input[0]
        .split(' | ')
        .map(property => removePipesAndSpaces(property));

    for (let i = 1; i < input.length; i++) {
        let currentRow = input[i]
            .split(' | ')
            .map(property => removePipesAndSpaces(property));
       
        let town = {}

        for (let j = 0; j < propertiesRow.length; j++) {
            if (j === 0) {
                town[propertiesRow[j]] = currentRow[j];
            } else {
                town[propertiesRow[j]] = parseFloat(parseFloat(currentRow[j]).toFixed(2));
            }
        }

        table.push(town);
    }
    
    return JSON.stringify(table);
}

function rectangle(width, height, color) {
    return {
        width: width,
        height: height,
        color: color[0].toUpperCase() + color.slice(1),
        calcArea: function() {
            return this.width * this.height;
        }
    }
}

function sortedList() {
    function sortList(list){
        list.sort((a, b) => a - b);

        return list;
    }

    return {
        elements: [],
        add: function(element){
            this.elements.push(element);
            this.size++;
            this.elements = sortList(this.elements);
        },
        remove: function(index) {
            if (index >= 0 && index <= this.elements.length - 1) {
                this.elements.splice(index, 1);
                this.size--;
                this.elements = sortList(this.elements);
            }
        },
        get: function(index) {
            if (index >= 0 && index <= this.elements.length - 1) {
                return this.elements[index];
            }
        },
        size: 0
    };
}

function heroes() {
    return {
        mage: function(name) {
            return {
                name: name,
                health: 100,
                mana: 100,
                cast: function(spell) {
                    this.mana--;
                    console.log(`${this.name} cast ${spell}`);
                }
            };
        },
        fighter: function(name) {
            return {
                name: name,
                health: 100,
                stamina: 100,
                fight: function() {
                    this.stamina--;
                    console.log(`${this.name} slashes at the foe!`);
                }
            };
        }
    };
}

function jansNotation(input) {
    let calculator = {
        numbers: [],
        '+': function(){
            if (this.numbers.length >= 2) {
                let [first, second] = this.numbers.splice(this.numbers.length - 2);
                this.numbers.push(first + second);
            }
            else{
                this.hasThrown = true;
            }
        },
        '-': function(){
            if (this.numbers.length >= 2) {
                let [first, second] = this.numbers.splice(this.numbers.length - 2);
                this.numbers.push(first - second);
            }
            else{
                this.hasThrown = true;
            }
        },
        '/': function(){
            if (this.numbers.length >= 2) {
                let [first, second] = this.numbers.splice(this.numbers.length - 2);
                this.numbers.push(first / second);
            }
            else{
                this.hasThrown = true;
            }
        },
        '*': function(){
            if (this.numbers.length >= 2) {
                let [first, second] = this.numbers.splice(this.numbers.length - 2);
                this.numbers.push(first * second);
            }
            else{
                this.hasThrown = true;
            }
        },
        hasThrown: false
    }

    input.forEach(command => {
        if (typeof command === 'string') {
            calculator[command]();
        } 
        else {
            calculator.numbers.push(command);
        }
    });

    if (calculator.hasThrown) {
        console.log('Error: not enough operands!');
    } else if (calculator.numbers.length === 1) {
        console.log(calculator.numbers[0]);
    } else{
        console.log('Error: too many operands!');
    }
       
}