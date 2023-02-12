function attachEvents() {
    document.querySelector('#btnLoad').addEventListener('click', GetAllPhones);
    document.querySelector('#btnCreate').addEventListener('click', CreatePhone);
}

function LoadPhones(data){
    const ul = document.querySelector('#phonebook');

    ul.innerHTML = '';

    data.forEach(ph => {
        const li = document.createElement('li');
        li.id = ph._id;
        li.textContent = `${ph.person}: ${ph.phone}`;

        const btn = document.createElement('button');
        btn.textContent = 'Delete';
        btn.addEventListener('click', DeletePhone);

        li.appendChild(btn);
        ul.appendChild(li);
    });
}

function DeletePhone (e){
    const id = e.target.parentElement.id;

    Delete(id);
    e.target.parentElement.remove();
}

function CreatePhone(e){
    const personInput = document.querySelector('#person');
    const phoneInput = document.querySelector('#phone');

    Create(personInput.value, phoneInput.value);

    personInput.value = "";
    phoneInput.value = "";

    GetAllPhones();
}

async function GetAllPhones(){
    const url = "http://localhost:3030/jsonstore/phonebook";

    const response = await fetch(url);
    const data = await response.json();

    LoadPhones(Object.values(data));
}

async function Create(person, phone){
    const url = "http://localhost:3030/jsonstore/phonebook";

    const body = {
        person,
        phone
    }

    const header = CreateHeader('post', body);

    const response = await fetch(url, header);
    const data = await response.json();
}

async function Delete(id){
    const url = `http://localhost:3030/jsonstore/phonebook/${id}`;

    const header = CreateHeader('delete', null);

    const response = await fetch(url, header);
    const data = await response.json();
}

function CreateHeader(method, body){
    return {
        method: method,
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(body)
    }
}

attachEvents();