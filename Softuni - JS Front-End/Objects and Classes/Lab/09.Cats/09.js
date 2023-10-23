function cats(input) {
    let array = input.toString().split(',');
    class Cat{
        constructor(name,age){
        this.name=name;
        this.age=age;
        }
        meow(){
        console.log(this.name+", age "+this.age+" says Meow");
        }
    }
    for (let index = 0; index < array.length; index++) {
       let split = array[index].toString().split(" ");
       let name = split[0];
       let age = split[1];
       let cat = new Cat(name,age);
       cat.meow();
    }
}