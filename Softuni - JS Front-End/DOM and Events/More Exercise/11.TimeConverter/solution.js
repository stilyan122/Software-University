function attachEventsListeners() {
   const daysBtn = document.getElementById('daysBtn');
   const hoursBtn = document.getElementById('hoursBtn');
   const minutesBtn = document.getElementById('minutesBtn');
   const secondsBtn = document.getElementById('secondsBtn');

   const daysInput = document.getElementById('days');
   const hoursInput = document.getElementById('hours');
   const minutesInput = document.getElementById('minutes');
   const secondsInput = document.getElementById('seconds');

    daysBtn.addEventListener('click',function(){
       const days = daysInput.value;
       hoursInput.value = days * 24;
       minutesInput.value = hoursInput.value * 60;
       secondsInput.value = minutesInput.value * 60;
   });

    hoursBtn.addEventListener('click',function(){
    const hours = hoursInput.value;
    daysInput.value = hours / 24;
    minutesInput.value = hoursInput.value * 60;
    secondsInput.value = minutesInput.value * 60;
    }); 

    minutesBtn.addEventListener('click',function(){
        const minutes = minutesInput.value;
        hoursInput.value = minutes / 60;
        daysInput.value = hoursInput.value / 24;
        secondsInput.value = minutesInput.value * 60;
    });
    secondsBtn.addEventListener('click',function(){
        const seconds = secondsInput.value;
        minutesInput.value = seconds / 60;
        hoursInput.value = minutesInput.value / 60;
        daysInput.value = hoursInput.value / 24;
    });
}