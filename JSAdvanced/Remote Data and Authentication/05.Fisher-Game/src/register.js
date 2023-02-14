document.querySelector('form')
.addEventListener('submit', RegisterUser);
document.querySelector('#user').style.display = "none";
document.querySelector('#home').classList.remove('active');
document.querySelector('#register').classList.add('active');

async function RegisterUser(e){
    e.preventDefault();
    const form = e.target;

    const formData = new FormData(form);

    const registerObj = Object.fromEntries(formData);

    if (registerObj.email === '' || registerObj.email === undefined ||
        registerObj.password === '' || registerObj.password === undefined ||
        registerObj.rePass === '' || registerObj.rePass === undefined) {
        document.querySelector('.notification').textContent = 'All fields are required';
        return;
    }

    const data = await Register(registerObj.email, registerObj.password);

    if (data.code) {
        document.querySelector('.notification').textContent = data.message;
        return
    }

    sessionStorage.setItem('accessToken', data.accessToken);
    sessionStorage.setItem('id', data._id);
    sessionStorage.setItem('email', data.email);

    window.location.href = 'http://127.0.0.1:5500/Remote%20Data%20and%20Authentication/05.Fisher-Game/src/index.html'
}

async function Register(email, password){
const url = "http://localhost:3030/users/register";

    const body = {
        email,
        password
    }

    const response = await fetch(url, {
        method: 'post',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(body)
    });

    const data = await response.json();

    return data;
}