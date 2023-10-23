function lockedProfile() {
    const profiles = Array.from(document.getElementsByClassName('profile'));
    let counter = 1;
    for (const profile of profiles) {
        const button = profile.getElementsByTagName('button')[0];
        const lock = profile.querySelectorAll('input[type="radio"]')[0];
        const fields = document.getElementById('user'+counter+'HiddenFields');
        button.addEventListener('click',show);
        function show() {
           if(!lock.checked && button.textContent === 'Show more'){
            fields.style.display = 'block';
            button.textContent='Hide it';
           }
           else if(!lock.checked && button.textContent === 'Hide it' && fields.style.display === 'block'){
            fields.style.display = 'none';
            button.textContent='Show more';
           }
        }
        counter++;
    }
}