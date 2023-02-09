async function lockedProfile() {
    const url = "http://localhost:3030/jsonstore/advanced/profiles";
    const main = document.querySelector('#main');
    let initDiv = document.querySelector('.profile');

    document.querySelector('button').addEventListener('click', onClick)
    document.querySelector('.user1Username').style.display = 'none';

    const response = await fetch(url);
    const data = await response.json();
    const prfileDataArray = Object.values(data);

    for (let i = 0; i < prfileDataArray.length; i++) {
        if (i == 0) {
            ApplayUserDataInCard(prfileDataArray[i]);
            continue;
        }

        CreateCard();
        ApplayUserDataInCard(prfileDataArray[i]);
    }


    function CreateCard(){
        let div = document.createElement('div');
        div.classList.add('profile');

        let img = document.createElement('img');
        img.classList.add('userIcon');
        img.src = './iconProfile2.png';

        let lockLabel = document.createElement('label');
        lockLabel.textContent = 'Lock'

        let lockedRadio = document.createElement('input');
        lockedRadio.type = 'radio';
        lockedRadio.name = `user1Locked`;
        lockedRadio.value = 'lock';
        lockedRadio.checked = true;

        let unlockLabel = document.createElement('label');
        unlockLabel.textContent = 'Unlock';

        let unlockedRadio = document.createElement('input');
        unlockedRadio.type = 'radio';
        unlockedRadio.name = `user1Locked`;
        unlockedRadio.value = 'unlock';

        let nameLabel = document.createElement('label');
        nameLabel.textContent = 'Username';

        let username = document.createElement('input');
        username.type = 'text';
        username.name = `user1Username`;
        username.value = '';
        username.disabled = true;
        username.readonly = true;

        let hiddenDiv = document.createElement('div');
        hiddenDiv.classList.add('user1Username');
        hiddenDiv.style.display = 'none';

        let emailLabel = document.createElement('label');
        emailLabel.textContent = 'Email:';

        let email = document.createElement('input');
        email.type = 'email';
        email.name = `user1Email`;
        email.value = '';
        email.disabled = true;
        email.readonly = true;

        let ageLabel = document.createElement('label');
        ageLabel.textContent = 'Age:';

        let age = document.createElement('input');
        age.type = 'text';
        age.name = `user1Age`;
        age.value = '';
        age.disabled = true;
        age.readonly = true;

        let btn = document.createElement('button');
        btn.textContent = 'Show more';
        btn.addEventListener('click', onClick);

        hiddenDiv.appendChild(document.createElement('hr'));
        hiddenDiv.appendChild(emailLabel);
        hiddenDiv.appendChild(email);
        hiddenDiv.appendChild(ageLabel);
        hiddenDiv.appendChild(age);

        div.appendChild(img);
        div.appendChild(lockLabel);
        div.appendChild(lockedRadio);
        div.appendChild(unlockLabel);
        div.appendChild(unlockedRadio);
        div.appendChild(document.createElement('hr'));
        div.appendChild(nameLabel);
        div.appendChild(username);
        div.appendChild(hiddenDiv);
        div.appendChild(btn);

        main.appendChild(div);

        initDiv = div;
    }

    function ApplayUserDataInCard(user){
        initDiv.querySelector('input[name="user1Username"]').value = user.username;
        initDiv.querySelector('input[name="user1Email"]').value = user.email;
        initDiv.querySelector('input[name="user1Age"]').value = user.age;
    }

    function onClick(e){
        let isLock = e.target.parentElement.querySelector('input[type="radio"]').checked;
        if (!isLock) {
            const div = e.target.parentElement.querySelector('div')
            if (div.style.display == 'none') {
                div.style.display = 'inline-block';
                e.target.textContent = 'Hide it';
            } else {
                div.style.display = 'none';
                e.target.textContent = 'Show more';
            }
        }
    }
}