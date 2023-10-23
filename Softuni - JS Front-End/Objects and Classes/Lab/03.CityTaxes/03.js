function cityTaxes(name,population,treasury) {
 let object = {name:name,population:population,treasury:treasury,taxRate:10,
 collectTaxes : function collectTaxes(){
    this.treasury+=this.population*this.taxRate;
    this.treasury=Math.floor(this.treasury);
 }
,applyGrowth: function applyGrowth(percentage){
    this.population+=this.population*(percentage/100);
    this.population=Math.floor(this.population);
}
,applyRecession: function applyRecession(percentage){
    this.treasury-=this.treasury*(percentage/100);
    this.treasury=Math.floor(this.treasury);
}}
return object;
}
