function validate() {
    const box = document.getElementById('email');
    box.addEventListener('change',function(){
        const regex = /([a-z]+)\@([a-z]+)\.([a-z]+)/g;
        const value = box.value;
        if(regex.exec(value)!==null){
            box.classList.remove('error')
        }
        else{
            box.classList.add('error');
        }
    });
}