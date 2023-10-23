function pyramidBuilding(base,increment) {
    let layers = Math.ceil(base/2);
    let stone = 0;
    let marble = 0;
    let gold = 0;
    let lapis = 0;
    for (let index = 1; index <= layers; index++) {
        if (index%5===0 && index<layers) {
            lapis+=((base*4)-4)*increment;
            stone+=(base-2)*(base-2)*increment;
        }
        else{
            if(index<=layers-1){
               stone+=(base-2)*(base-2)*increment;
               marble+=((base*4)-4)*increment;
            }
            else{
               gold+=base*base*increment;
            }
        }
        base-=2;
    }
    console.log("Stone required: "+Math.ceil(stone));
    console.log("Marble required: "+Math.ceil(marble));
    console.log("Lapis Lazuli required: "+Math.ceil(lapis));
    console.log("Gold required: "+Math.ceil(gold));
    console.log("Final pyramid height: "+Math.floor(layers*increment));
}