function catalogue(input) {
    class Product {
        constructor(name,price){
            this.name=name;
            this.price=price;
        }
    }
    let products = {};
    for (const command of input) {
        const name = command.split(' : ')[0];
        const price = command.split(' : ')[1];
        const product = new Product(name,price);
        const letter = name[0];
        if(products.hasOwnProperty(letter)){
            products[letter].push(product);
        }
        else{
            products[letter] = [];
            products[letter].push(product);
        }
    }
    Object.keys(products).sort((a,b)=>a.localeCompare(b)).forEach(
    (product) =>
    {
        console.log(product);
        products[product].sort((a,b)=> a.name.localeCompare(b.name)).forEach((product)=>{
            console.log(`  ${product.name}: ${product.price}`)
        });
    })
}