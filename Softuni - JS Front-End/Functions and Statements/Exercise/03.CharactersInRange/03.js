function charactersFromTheASCII(char1,char2) {
    let result="";
    let startCode = char1.charCodeAt(0);
    let endCode = char2.charCodeAt(0);
    if (startCode<endCode) {
        for (let index = startCode+1; index < endCode; index++) {
        result+=(String.fromCharCode(index)+" ");
        }
    }
    else{
        for (let index = endCode+1; index < startCode; index++) {
        result+=(String.fromCharCode(index)+" ");
        }
    }
    console.log(result);
}