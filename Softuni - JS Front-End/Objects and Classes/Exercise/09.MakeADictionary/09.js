function dictionary(input) {
    class Product{
        constructor(term,desc){
            this.term = term,
            this.desc = desc
        }
    }
    let output = [];
    for (const text of input) {
      const object = JSON.parse(text);
      const keys = Object.keys(object);
      const values = Object.values(object);
      const key = keys[0];
      const value = values[0];
      const product = new Product(key,value);
      const check = output.find((entry) => entry.term === product.term);
      if(check===undefined){
        output.push(product);
      }
      else{
        check.desc = product.desc;
      }
    }
    output.sort((a,b) => a.term.localeCompare(b.term)).forEach((product)=>
    {
        console.log(`Term: ${product.term} => Definition: ${product.desc}`)
    })
}
