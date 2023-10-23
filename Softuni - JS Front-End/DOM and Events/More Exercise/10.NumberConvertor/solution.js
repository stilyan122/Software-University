function solve() {
   const option1 = document.createElement('option');
   const option2 = document.createElement('option');
   const optionList = document.getElementById('selectMenuTo');
   const output = document.getElementById('result');
   option1.value = 'binary';
   option1.textContent = 'Binary';
   option2.value = 'hexadecimal';
   option2.textContent = 'Hexadecimal';
   optionList.appendChild(option1);
   optionList.appendChild(option2);
   const button = document.getElementById('container').getElementsByTagName('button')[0];
   button.addEventListener('click',function(){
    const typeOfOption = optionList.value;
    const number = Number(document.getElementById('input').value);
    if(typeOfOption==='binary'){
       output.value=number.toString(2);
    }
    else{
        output.value=number.toString(16).toUpperCase();
    }
   });
}