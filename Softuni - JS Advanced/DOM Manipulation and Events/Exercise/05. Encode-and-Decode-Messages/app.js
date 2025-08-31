function encodeAndDecodeMessages() {
    let main = document.getElementById('main');

    let encoderDiv = main.getElementsByTagName('div')[0];
    let decoderDiv = main.getElementsByTagName('div')[1];

    let encoderTextArea = encoderDiv.getElementsByTagName('textarea')[0];
    let decoderTextArea = decoderDiv.getElementsByTagName('textarea')[0];

    let encoderBtn = encoderDiv.getElementsByTagName('button')[0];
    let decoderBtn = decoderDiv.getElementsByTagName('button')[0];

    encoderBtn.addEventListener('click', () => {
        let message = encoderTextArea.value;
        let encodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            encodedMessage += String.fromCharCode(message.charCodeAt(i) + 1);
        }

        encoderTextArea.value = '';
        decoderTextArea.value = encodedMessage;
    });

    decoderBtn.addEventListener('click', () => {
        let message = decoderTextArea.value;
        let decodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            decodedMessage += String.fromCharCode(message.charCodeAt(i) - 1);
        }

        decoderTextArea.value = decodedMessage;
    });
}