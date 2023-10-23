function attachGradientEvents() {
    const box = document.getElementById('gradient');
    const result = document.getElementById('result');
    box.addEventListener('mousemove',function(event){
       result.textContent = (Math.floor(event.offsetX/box.clientWidth*100))+`%`;
    });
}