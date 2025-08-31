function sortArray(items, sortType)
{
    const getComparator = (sortType) => {
        return sortType === 'asc'
            ? (a, b) => a - b
            : (a, b) => b - a;
    };

    const comparator = getComparator(sortType);
    return items.sort(comparator);
};

function argumentInfo() {
    const result = {};

    for (const arg of arguments) {
        const type = typeof arg;
        console.log(`${type}: ${arg}`);

        if (!result[type]) {
            result[type] = 0;
        }

        result[type]++;
    }

    Object.entries(result)
        .sort((a, b) => b[1] - a[1])
        .forEach(([type, count]) => console.log(`${type} = ${count}`));
}

function getFibonator(){
    let currentFib = 1;
    let prevFib = 0;

    return function() {
        let nextFib = prevFib + currentFib;
        prevFib = currentFib;
        currentFib = nextFib;
        return prevFib;
    };
}

function breakfastRobot(){
    const recipes = {
        apple: {carbohydrate: 1, flavour: 2},
        lemonade: {carbohydrate: 10, flavour: 20},
        burger: {carbohydrate: 5, fat: 7, flavour: 3},
        eggs: {protein: 5, fat: 1, flavour: 1},
        turkey: {protein: 10, carbohydrate: 10, fat: 10, flavour: 10}
    };

    const stock = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    const commands = {
        restock: (microelement, quantity) => {
            stock[microelement] += quantity;
            return 'Success';
        },
        prepare: (product, quantity) => {
            const recipe = recipes[product];
            for (const microelement in recipe) {
                if (recipe[microelement] * quantity > stock[microelement]) {
                    return `Error: not enough ${microelement} in stock`;
                }
            }

            for (const microelement in recipe) {
                stock[microelement] -= recipe[microelement] * quantity;
            }

            return 'Success';
        },
        report: () => Object.entries(stock)
            .map(([microelement, quantity]) => `${microelement}=${quantity}`)
            .join(' ')
    };

    return (input) => {
        const [command, item, quantity] = input.split(' ');
        return commands[command](item, +quantity);
    };
}

function add(number){
    let sum = number;

    function calc(n){
        sum += n;
        return calc;
    }

    calc.toString = () => sum;

    return calc;
}

function monkeyPatcher(command){
    if(command === 'upvote'){
        this.upvotes++;
    } else if(command === 'downvote'){
        this.downvotes++;
    } else if(command === 'score'){
        let score = 'new';

        let reportUpvotes = this.upvotes;
        let reportDownvotes = this.downvotes;

        if(this.upvotes + this.downvotes > 50){
            let moreVotes = Math.ceil(Math.max(this.upvotes, this.downvotes) * 0.25);
            reportUpvotes += moreVotes;
            reportDownvotes += moreVotes;
        }

        let sum = this.upvotes + this.downvotes;
        let balance = this.upvotes - this.downvotes;

        let positiveVotesPercentage = this.upvotes / sum * 100;

        if(positiveVotesPercentage > 66){
            score = 'hot';
        } else if(balance >= 0 && sum > 100){
            score = 'controversial';
        } else if(balance < 0){
            score = 'unpopular';
        }

        if(reportUpvotes + reportDownvotes < 10){
            score = 'new';
        }

        return [reportUpvotes, reportDownvotes, balance, score];
    }
}

