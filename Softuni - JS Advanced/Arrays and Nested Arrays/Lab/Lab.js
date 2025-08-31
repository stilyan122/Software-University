function evenPositionElement(array) {
    const filtered = array.filter((element, index) => index % 2 === 0);
    console.log(filtered.join(' '));
}

function lastKSequence(n, k) {
    let array = [1];
    for (let index = 1; index < n; index++) {
        array[index] = array.reduce((prev, current, i, arr) => {
            if (i !== index - k) {
                current += prev;
            }

            return current;
        });
    }

    return array;
}

function sumFirstLast(array) {
    const last = parseFloat(array.pop());
    const first = parseFloat(array.shift());
    const sum = first + last;

    return sum; 
}

function negativePositiveNumbers(array) {
    let arr = [];

    array.forEach(element => {
        if (element < 0) {
            arr.unshift(element);
        } else {
            arr.push(element);
        }
    });

    arr.forEach(element => {
        console.log(element);
    });
}

function smallestTwoNumbers(array) {
    array.sort((a,b) => a-b);
    console.log(`${array[0]} ${array[1]}`);
}

function biggerHalf(array) {
    array.sort((a,b) => a - b);

    return array.slice(array.length / 2);
}

function pieceOfPie(flavors, fl1, fl2) {
    let i1 = flavors.indexOf(fl1);
    let i2 = flavors.indexOf(fl2);

    return flavors.slice(i1, i2 + 1);
}

function processOddPositions(array) {
    let odds = array.filter((element, index) => index % 2 === 1);
    let mapped = odds.map((odd) => odd * 2);
    mapped.reverse();

    return mapped;
}

function biggestElement(matrix) {
    let max = Math.max(...(matrix[0]));

    matrix.forEach(array => {
        let current = Math.max(...array);
        if (current > max) {
            max = current;
        }
    });
    return max;
}

function diagonalSums(matrix) {
    let sum1 = 0;
    let sum2 = 0;

    let firstIndex = 0;
    let secondIndex = matrix[0].length - 1;

    matrix.forEach(array => {
        sum1 += array[firstIndex];
        firstIndex++;

        sum2 += array[secondIndex];
        secondIndex--;
    });

    console.log(`${sum1} ${sum2}`);
}

function equalNeighbors(matrix) {
    let pairs = 0;

    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            if (j < matrix[i].length - 1 && matrix[i][j] === matrix[i][j + 1]) {
                pairs++;
            }

            if (i < matrix.length - 1 && matrix[i][j] === matrix[i + 1][j]) {
                pairs++;
            }
        }
    }

    return pairs;
}