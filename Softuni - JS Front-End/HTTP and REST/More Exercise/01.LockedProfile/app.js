function lockedProfile() {
    const URL = 'http://localhost:3030/jsonstore/advanced/profiles';

    const main = document.getElementById('main');

    fetch(URL)
    .then((res)=>{
        res.json()
        .then((json)=>{
            for (const entry of Object.entries(json)) {
                const values = entry[1];
                const ageValue = values.age;
                const usernameValue = values.username;
                const emailValue = values.email;

                const divCard = document.createElement('div');
                divCard.classList.add('profile');

                const image = document.createElement('img');
                image.src='./iconProfile2.png';
                image.classList.add('userIcon');
                divCard.appendChild(image);

                const lock = document.createElement('label');
                lock.textContent='Lock';
                divCard.appendChild(lock);

                const lockInput = document.createElement('input');
                lockInput.type='radio';
                lockInput.name='user1Locked';
                lockInput.value='lock';
                lockInput.checked=true;
                divCard.appendChild(lockInput);

                const unlock = document.createElement('label');
                unlock.textContent='Unlock';
                divCard.appendChild(unlock);

                const unlockInput = document.createElement('input');
                unlockInput.type='radio';
                unlockInput.name='user1Locked';
                unlockInput.value='unlock';
                divCard.appendChild(unlockInput);

                const br = document.createElement('br');
                divCard.appendChild(br);

                const hr = document.createElement('hr');
                divCard.appendChild(hr);


                const username = document.createElement('label');
                username.textContent='Username';
                divCard.appendChild(username);

                const usernameInput = document.createElement('input');
                usernameInput.type='text';
                usernameInput.name='user1Username';
                usernameInput.value=usernameValue;
                usernameInput.disabled=true;
                usernameInput.readOnly=true;
                divCard.appendChild(usernameInput);

                const divInfo = document.createElement('div');
                divInfo.classList.add('user1HiddenFields');
                divInfo.style.display='none';
                divInfo.appendChild(hr);

                const email = document.createElement('label');
                email.textContent='Email:';
                divInfo.appendChild(email);

                const emailInput = document.createElement('input');
                emailInput.type='email';
                emailInput.name='user1Email';
                emailInput.value=emailValue;
                emailInput.disabled=true;
                emailInput.readOnly=true;
                divInfo.appendChild(emailInput);

                const age = document.createElement('label');
                age.textContent='Age:';
                divInfo.appendChild(age);

                const ageInput = document.createElement('input');
                ageInput.type='email';
                ageInput.name='user1Age';
                ageInput.value=ageValue;
                ageInput.disabled=true;
                ageInput.readOnly=true;
                divInfo.appendChild(ageInput);

                divCard.appendChild(divInfo);

                const button = document.createElement('button');

                button.addEventListener('click',function(){
                    if(button.textContent==='Show more' && unlockInput.checked){
                        divInfo.style.display='block';
                        button.text='Hide it';
                    }
                    else if(button.textContent==='Hide it' && unlockInput.checked){
                        divInfo.style.display='none';
                        button.text='Show more';
                    }
                });

                button.textContent='Show more';
                divCard.appendChild(button);

                main.appendChild(divCard);
            }
        })
    })
}