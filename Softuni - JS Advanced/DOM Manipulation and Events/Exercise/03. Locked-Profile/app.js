function lockedProfile() {
    let profiles = Array.from(document.getElementsByClassName('profile'));

    profiles.forEach(profile => {
        let button = profile.querySelector('button');
        button.addEventListener('click', function(){
            let isLocked = profile
                .querySelector('input[type="radio"][value="lock"]').checked;
            let hiddenDiv = profile.querySelector('div');

            if(!isLocked){
                if(button.textContent === 'Show more'){
                    hiddenDiv.style.display = 'block';
                    button.textContent = 'Hide it';
                } else {
                    hiddenDiv.style.display = 'none';
                    button.textContent = 'Show more';
                }
            }
        });
    });
}