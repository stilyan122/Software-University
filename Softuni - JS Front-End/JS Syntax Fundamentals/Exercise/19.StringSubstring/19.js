function substring(word,text) {
   let array = text.split(" ");
   let found = false;
   for (const arrayEl of array) {
     if (arrayEl.toLowerCase()===word.toLowerCase()) {
        console.log(word);
        found=true;
        break;
     }
   }
   if (found===false) {
    console.log(word+' not found!');
   }
}