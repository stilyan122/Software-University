function calculator() {
    return {
        init: (selector1, selector2, resultSelector) => {
            this.firstElement = document.querySelector(selector1);
            this.secondElement = document.querySelector(selector2);
            this.resultElement = document.querySelector(resultSelector);    
        },
        add: () => {
            this.resultElement.value = Number(this.firstElement.value) + 
                Number(this.secondElement.value);
        },
        subtract: () => {
            this.resultElement.value = Number(this.firstElement.value) - 
                Number(this.secondElement.value);
        }
    };
}