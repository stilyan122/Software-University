function validate() {
    let email = document.getElementById('email');
    email.addEventListener('change', onChange);

    function onChange(ev) {
        let pattern = /^[a-z]+@[a-z]+\.[a-z]+$/;
        if (!pattern.test(email.value)) {
            email.classList.add('error');
        } else {
            email.classList.remove('error');
        }
    }
}