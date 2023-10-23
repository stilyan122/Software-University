function movies(input) {
  let movieArr=[];
  const array = input.toString().split(',');
  class Movie{
    constructor(name,director,date){
      this.name=name;
      this.director=director;
      this.date=date;
    }
  }    
  function split(string,index,length){
    return string.split(' ').slice(index,length).join(' ');
  }
  const commands = {
    addMovie:(name) => movieArr.push(new Movie(name,undefined,undefined)),
    contains:(name) => movieArr.find(n=>n.name===name)
  } 
  for (const command of array) {
    if(command.includes('addMovie')){
      commands.addMovie(split(command,1,command.split(' ').length));
    }
    else if(command.includes('directedBy')){
      const index = command.split(' ').indexOf('directedBy');
      const name = split(command,0,index);
      const director = split(command,index+1,command.split(' ').length);
      if(commands.contains(name)!==undefined){
        commands.contains(name).director=director;
      }
    }
    else{
      const index = command.split(' ').indexOf('onDate');
      const name = split(command,0,index);
      const date = split(command,index+1,command.split(' ').length);
      if(commands.contains(name)!==undefined){
        commands.contains(name).date=date;
      }
    }
  }
  movieArr.forEach((movie)=>
  {
    if(movie.name!==undefined && movie.director!==undefined && movie.date!==undefined)
    console.log(JSON.stringify(movie));
  });
}