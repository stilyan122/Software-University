// 01.

function sum(arr, start, end) {
    if (!Array.isArray(arr)) {
        return NaN;
    }
    if (start < 0) {
        start = 0;
    }
    if (end > arr.length - 1) {
        end = arr.length - 1;
    }
    arr = arr.map(curr => Number(curr));
    return arr.slice(start, end + 1).reduce((a, b) => a + b, 0);
}

// 02.

function cardFactory(face, suit){
    let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

        if(!faces.includes(face)){
            throw new Error("Error");
        }

        let suits = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663'
        };

        suit = suits[suit];

        return {
            face: face,
            suit: suit,
            toString: function() {
                return `${face}${suit}`;
            }
        };
}

// 03.

function printDeckOfCards(cards) {
    function createCard(face, suit) {
        const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

        if (!faces.includes(face)) {
            throw new Error(`${face}${suit}`);
        }

        const suits = {
            S: '\u2660', 
            H: '\u2665',
            D: '\u2666',
            C: '\u2663'  
        };

        if (!suits[suit]) {
            throw new Error(`${face}${suit}`);
        }

        return {
            face,
            suit: suits[suit],
            toString() {
                return `${this.face}${this.suit}`;
            }
        };
    }

    const result = [];

    try {
        for (const card of cards) {
            const face = card.slice(0, -1);
            const suit = card.slice(-1);

            const cardObj = createCard(face, suit);

            result.push(cardObj.toString());
        }

        console.log(result.join(' '));
    } catch (err) {
        console.log('Invalid card: ' + err.message);
    }
}