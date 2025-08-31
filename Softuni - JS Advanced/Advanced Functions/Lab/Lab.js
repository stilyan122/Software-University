// 01. Area and Volume Calculator

function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};

function solve(area, vol, input) {
    let output = [];

    let data = JSON.parse(input);

    data.forEach(obj => {
        let x = obj['x'];
        let y = obj['y'];
        let z = obj['z'];

        let result = {
            area: area.call({ x, y }),
            volume: vol.call({ x, y, z })
        };

        output.push(result);
    });

    return output;
}

// 02. Add

function solution(number){
    return function(num) {
        return number + num;
    };
}

// 03. Currency Format

function currencyFormatter(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2,2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}

function createFormater(separator, symbol, symbolFirst, currencyFormatter) {
    return function(value) {
        return currencyFormatter(separator, symbol, symbolFirst, value);
    };
}

// 04. Filter Employees

function filterEmployees(data, criteria) {
    let employees = JSON.parse(data);
    let [key, value] = criteria.split('-');

    let final = employees
        .filter(employee => employee[key] === value || key === 'all')
        .map((employee, index) => `${index}. ${employee.first_name} ${employee.last_name} - ${employee.email}`);

    final.forEach(e => console.log(e));
}

// 05. Command Processor

function solution() {
    let str = '';

    return {
        append: (s) => str += s,
        removeStart: (n) => str = str.slice(n),
        removeEnd: (n) => str = str.slice(0, -n),
        print: () => console.log(str)
    };
}

// 06. List Processor

function solution(input) {
    let closure = {
        list: [],
        add: (str) => closure.list.push(str),
        remove: (str) => closure.list = closure.list.filter(e => e !== str),
        print: () => console.log(closure.list.join(','))
    };

    input.forEach(e => {
        let [command, value] = e.split(' ');
        closure[command](value);
    });
}

// 07. Cars

function solve(input) {
    let closure = {
        items: [],
        create: (name) => {
            closure.items.push({ name, inherited: [], parent: null });
        },
        createInherit: (name, parentName) => {
            let parent = closure.items.find(e => e.name === parentName);

            let newItem = {
                name,
                inherited: [...parent.inherited],
                parent: parentName,
            };

            Object.entries(parent).forEach(([key, value]) => {
                if (!['name', 'parent', 'inherited'].includes(key)) {
                    newItem.inherited.push({ key, value });
                }
            });
            
            closure.items.push(newItem);
        },
        set: (name, key, value) => {
            let item = closure.items.find(e => e.name === name);
            item[key] = value;

            function propagateToChildren(name) {
                let children = closure.items.filter(e => e.parent === name);
                children.forEach(child => {
                    child.inherited.push({ key, value });
                    propagateToChildren(child.name);
                });
            }

            propagateToChildren(name);
        },
        print: (name) => {
            let item = closure.items.find(e => e.name === name);
            let ownProperties = Object.entries(item)
                .filter(e => !['name', 'parent', 'inherited'].includes(e[0]))
                .map(([key, value]) => `${key}:${value}`);

            let inheritedProperties = item.inherited.map(
                ({ key, value }) => `${key}:${value}`
            );

            console.log([...ownProperties, ...inheritedProperties].join(','));
        },
    };

    input.forEach(command => {
        let [action, ...args] = command.split(' ');

        if (action === 'create' && args.includes('inherit')) {
            let [name, , parentName] = args;
            closure.createInherit(name, parentName);
        } else if (action === 'create') {
            closure.create(args[0]);
        } else if (action === 'set') {
            let [name, key, value] = args;
            closure.set(name, key, value);
        } else if (action === 'print') {
            closure.print(args[0]);
        }
    });
}