function crystalise(input) {
    let array = input.toString().split(',');
    let finalThickness = parseInt(array[0]);
    let crystals = input.slice(1,array.length);
    for (let index = 0; index < crystals.length; index++) {
        console.log("Processing chunk "+crystals[index]+" microns");
        while (crystals[index]>finalThickness) {
            let cut = 0;
            let lap = 0;
            let grind = 0;
            let etch = 0;
            while(crystals[index]/4>finalThickness){
            if (crystals[index]/4>finalThickness) {
                crystals[index]/=4;
                cut++;
            }
            }
            if(crystals[index]/4==finalThickness){
                crystals[index]/=4;
                cut++;
                console.log("Cut x"+cut);
                console.log("Transporting and washing");
                crystals[index] = Math.floor(crystals[index]);
                break;
             }
            else if(crystals[index]/4<finalThickness){
                if(cut>0){
                 console.log("Cut x"+cut);
                 console.log("Transporting and washing");
                 crystals[index] = Math.floor(crystals[index]);
                }
             }
            while(crystals[index]-0.20*crystals[index]>finalThickness){
                if (crystals[index]-0.20*crystals[index]>finalThickness) {
                    crystals[index]-=0.20*crystals[index];
                    lap++;
                }
           }
            if(crystals[index]-0.20*crystals[index]==finalThickness){
            crystals[index]-=0.20*crystals[index];
            lap++;
            console.log("Lap x"+lap);
            console.log("Transporting and washing");
            crystals[index] = Math.floor(crystals[index]);
            break;
         }
         else if(crystals[index]-0.20*crystals[index]<finalThickness){
            if(lap>0){
             console.log("Lap x"+lap);
             console.log("Transporting and washing");
             crystals[index] = Math.floor(crystals[index]);
            }
         }
         while(crystals[index]-20>finalThickness){
            if (crystals[index]-20>finalThickness) {
                crystals[index]-=20;
                grind++;
            }
        }
            if(crystals[index]-20==finalThickness){
                crystals[index]-=20;
                grind++;
                console.log("Grind x"+grind);
                console.log("Transporting and washing");
                crystals[index] = Math.floor(crystals[index]);
                break;
             }
            else if(crystals[index]-20<finalThickness){
                if(grind>0){
                 console.log("Grind x"+grind);
                 console.log("Transporting and washing");
                 crystals[index] = Math.floor(crystals[index]);
                }
             }
             while(crystals[index]-2>finalThickness){
                if (crystals[index]-2>finalThickness) {
                    crystals[index]-=2;
                    etch++;
                }
                }
                if(crystals[index]-2==finalThickness){
                    crystals[index]-=2;
                    etch++;
                    if(etch>0){
                    console.log("Etch x"+etch);
                    console.log("Transporting and washing");
                    crystals[index] = Math.floor(crystals[index]);
                    }
                    break;
                 }
                else if(crystals[index]-2==finalThickness-1){
                     crystals[index]-=2;
                     etch++;
                     if(etch>0){
                     console.log("Etch x"+etch);
                     console.log("Transporting and washing");
                     crystals[index] = Math.floor(crystals[index]);
                     }
                     break;
                 } 
        }
        if(crystals[index]<finalThickness){
            console.log("X-ray x1");
            crystals[index]+=1;
            
        }
        if (crystals[index]==finalThickness) {
            console.log("Finished crystal "+crystals[index]+" microns");
        }
    }
}