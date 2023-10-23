function songs(input) {
    let songs =[];
    let counter = 0;
    class Song{
        constructor(typeList,name,time){
          this.typeList=typeList;
          this.name=name;
          this.time=time;
        }

    }
    let array = input.toString().split(",");
    let n = Number(array[0]);
    for (let index = 1; index < n+1; index++) {
        let splitted = array[index].toString().split("_");
        let typeList = splitted[0];
        let name = splitted[1];
        let time = splitted[2];
        let song = new Song(typeList,name,time);
        songs[counter] = song;
        counter++;
    }
    let last = array[array.length-1];
    if (last=="all") {
        songs.forEach(element => {
            console.log(element.name);
        });
    }
    else{
       for (let index = 0; index < songs.length; index++) {
        const current = songs[index];
        if (current.typeList===last) {
            console.log(current.name);
        }
       }
    }
}