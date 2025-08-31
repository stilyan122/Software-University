function printAnArrayWithGivenDelimiter(array, delimeter) {
    console.log(array.join(delimeter));
}

function printEveryNthElementFromAnArray(array, step) {
    let map = array.filter((element, index) => index % step === 0);
    return map;
}

function addAndRemoveElements(array) {
    let output = [];
    let count = 1;

    array.forEach(element => {
        if (element === 'add'){
            output.push(count);
        }
        else if (element === 'remove') {
            output.pop();
        }

        count++;
    });

    output.forEach(element => {
        console.log(element);
    });

    if (output.length === 0) {
        console.log('Empty');
    }
}

function rotateArray(array, n) {
    for (let i = 0; i < n; i++) {
        let last = array.pop();
        array.unshift(last);
    }

    console.log(array.join(' '));
}

function extractIncreasingSubsequenceFromArray(array) {
    let map = array.reduce((result, current) => {
        if (result.length === 0 || current >= result[result.length - 1]) {
            result.push(current);
          }
        return result;
    }, []);

    return map;
}

function listOfNames(names) {
    names.sort((a,b) => a.localeCompare(b));
    for (let i = 0; i < names.length; i++) {
        const element = names[i];
        console.log(`${i+1}.${element}`);
    }
}

function sortingNumbers(array) {
    array.sort((a,b) => a-b);

    for (let i = 0; i < array.length; i+=2) {
        let last = array.pop();
        array.splice(i+1, 0, last);
    }

    return array;
}

function sortAnArrayByTwoCriteria(array) {
    array.sort((a, b) => {
        if (a.length === b.length) {
            return a.toLowerCase().localeCompare(b.toLowerCase());
        }

        return a.length - b.length;
    });

    array.forEach(element => {
        console.log(element);
    });
}

function magicMatrices(matrix) {
    let sum = 0;

    for (let i = 0; i < matrix.length; i++) {
        let currentSum = matrix[i].reduce((a, b) => a + b, 0);
        if (i === 0) {
            sum = currentSum;m
        } else if (sum !== currentSum) {
            return false; 
        }
    }

    for (let i = 0; i < matrix[0].length; i++) {
        let currentSum = 0;
        for (let j = 0; j < matrix.length; j++) {
            currentSum += matrix[j][i];
        }
        if (sum !== currentSum) {
            return false; 
        }
    }

    return true;
}

function ticTacToe(moves) {
    let board = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    let isXOnTurn = true;
    let winner = false;

    function checkWinner(x, y) {
        let playerSymbol = board[x][y];

        if (board[x].every(cell => cell === playerSymbol)) {
            return playerSymbol;
        }

        if (board.every(row => row[y] === playerSymbol)) {
            return playerSymbol;
        }

        if (x === y && board.every((row, index) => row[index] === playerSymbol)) {
            return playerSymbol;
        }

        if (x + y === board.length - 1 && board.every((row, index) => row[board.length - 1 - index] === playerSymbol)) {
            return playerSymbol;
        }

        return null;
    }

    function printBoard(board) {
        board.forEach(row => {
            console.log(row.map(cell => cell).join('\t'));
        });
    }

    for (let i = 0; i < moves.length; i++) {
        let [x, y] = moves[i].split(' ').map(Number);

        if (board[x][y] !== false) {
            console.log("This place is already taken. Please choose another!");
            continue;
        } 

        board[x][y] = isXOnTurn ? 'X' : 'O';
        let winnerSymbol = checkWinner(x, y);

        if (winnerSymbol) {
            console.log(`Player ${winnerSymbol} wins!`);
            printBoard(board);
            return;
        }

        if (!board.some(row => row.includes(false))) {
            console.log("The game ended! Nobody wins :(");
            printBoard(board);
            return;
        }

        isXOnTurn = !isXOnTurn;
    }
}

function diagonalAttack(matrix) {
    let sum1 = 0;
    let sum2 = 0;

    matrix = matrix.map(arr => arr.split(' ').map(Number));

    let n = matrix.length;

    for (let i = 0; i < n; i++) {
        sum1 += matrix[i][i];
        sum2 += matrix[i][n - 1 - i];
    }

    if (sum1 === sum2) {
        for (let i = 0; i < n; i++) {
            for (let j = 0; j < n; j++) {
                if (j !== i && j !== (n - 1 - i)) {
                    matrix[i][j] = sum1;
                }
            }
        }
    }

    matrix.forEach(array => {
        console.log(array.join(" "));
    });
}

function orbit(coords) {
    let [width, height, x, y] = coords;
    let matrix = [];

    for (let i = 0; i < height; i++) {
        matrix[i] = [];
        for (let j = 0; j < width; j++) {
            matrix[i][j] = 0;
        }
    }

    matrix[x][y] = 1;

    for (let i = 0; i < height; i++) {
        for (let j = 0; j < width; j++) {
            matrix[i][j] = Math.max(Math.abs(i - x), Math.abs(j - y)) + 1;
        }
    }

    matrix.forEach(row => console.log(row.join(' ')));
}

function spiralMatrix(width, height) {
    let matrix = [];

    for (let i = 0; i < height; i++) {
        matrix[i] = [];
        for (let j = 0; j < width; j++) {
            matrix[i][j] = 0;
        }
    }

    let current = 1;
    let top = 0, bottom = height - 1;
    let left = 0, right = width - 1;

    while (top <= bottom && left <= right) {

        for (let i = left; i <= right; i++) {
            matrix[top][i] = current++;
        }
        top++; 

        for (let i = top; i <= bottom; i++) {
            matrix[i][right] = current++;
        }
        right--;

        if (top <= bottom) {
            for (let i = right; i >= left; i--) {
                matrix[bottom][i] = current++;
            }
            bottom--;
        }

        if (left <= right) {
            for (let i = bottom; i >= top; i--) {
                matrix[i][left] = current++;
            }
            left++;
        }
    }

    matrix.forEach(row => console.log(row.join(' ')));
}