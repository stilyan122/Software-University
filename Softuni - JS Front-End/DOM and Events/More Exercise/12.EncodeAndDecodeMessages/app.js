function encodeAndDecodeMessages() {
    const mainDivs = document.getElementById('main').getElementsByTagName('div');
    const encodeBtn = mainDivs[0].getElementsByTagName('button')[0];
    const decodeBtn = mainDivs[1].getElementsByTagName('button')[0];
    const encodeMsgInput = mainDivs[0].getElementsByTagName('textarea')[0];
    const decodeMsgInput = mainDivs[1].getElementsByTagName('textarea')[0];

    encodeBtn.addEventListener('click',function(){
       const value = encodeMsgInput.value;
       let decodeMsg = "";
       for (const char of value) {
        const code = char.charCodeAt(0)+1;
        decodeMsg+=String.fromCharCode(code);
       }
       encodeMsgInput.value = "";
       decodeMsgInput.value = decodeMsg;
    });
    
    decodeBtn.addEventListener('click',function(){
        const value = decodeMsgInput.value;
        let encodeMsg = "";
        for (const char of value) {
         const code = char.charCodeAt(0)-1;
         encodeMsg+=String.fromCharCode(code);
        }
        decodeMsgInput.value = "";
        decodeMsgInput.value = encodeMsg;
     });
}