function focused() {
    let allInputs = document.querySelectorAll('input[type="text"]');
    allInputs.forEach(input => {
        input.addEventListener('focus', function (e) {
            allInputs.forEach(input => {
                input.parentElement.classList.remove('focused');
            });

            input.parentElement.classList.add('focused');
        });
    });
}