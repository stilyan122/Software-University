function laptop(){
   class Laptop{
    constructor(info,quality){
        this.info = {
            producer: info.producer,
            age: info.age,
            brand: info.brand
        }
        this.quality = quality;
        this.isOn = false,
        this.turnOn = function(){
           this.isOn=true;
           this.quality--;
        }
        this.turnOff = function(){
            this.isOn=false;
            this.quality--;
        }
        this.showInfo = function(){
            return JSON.stringify(info);
        }
    }
    get price() {
        return 800 - (this.info.age * 2) + (this.quality * 0.5); 
    }
   }
}
laptop();