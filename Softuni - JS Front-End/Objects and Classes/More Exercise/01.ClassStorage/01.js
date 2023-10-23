function storage() {
class Storage{
    constructor(capacity){
        this.capacity = capacity,
        this.storage = [];
        this.totalCost = 0;
    }
    addProduct(product){
        this.storage.push(product);
        this.totalCost += product.price * product.quantity;
        this.capacity -= product.quantity;
    }
    getProducts(){
        let text = "";
        for (let index = 0; index < this.storage.length; index++) {
            const product = this.storage[index];
            if(index<this.storage.length-1){
                text += JSON.stringify(product) + "\n";
            }
            else{
                text += JSON.stringify(product);
            }
        }
        return text;
    }
}
}
storage();