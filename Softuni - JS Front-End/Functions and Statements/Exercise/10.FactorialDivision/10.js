function factorial(n1,n2) {
    let fact1=1;
    let fact2=1;
    for (let index = 2; index <= n1; index++) {
        fact1*=index;
    }
    for (let index2 = 2; index2 <= n2; index2++) {
        fact2*=index2;
    }
    console.log((fact1/fact2).toFixed(2));
}