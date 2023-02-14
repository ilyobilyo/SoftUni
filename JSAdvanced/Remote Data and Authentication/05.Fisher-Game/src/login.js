document.querySelector('form').addEventListener('submit', LoginUser);
document.querySelector('#user').style.display = "none";
document.querySelector('#home').classList.remove('active');
document.querySelector('#login').classList.add('active');


async function LoginUser(e){
    e.preventDefault();
debugger
    const formData = new FormData(e.target);
    const formObj = Object.fromEntries(formData);

    if (formObj.email === '' || formObj.email === undefined ||
    formObj.password === '' || formObj.password === undefined) {
        document.querySelector('.notification').textContent = 'All fields are required';
        return;
    }

    const data = await Login(formObj.email, formObj.password);

    if (data.code) {
        document.querySelector('.notification').textContent = data.message;
        return
    }

    sessionStorage.setItem('accessToken', data.accessToken);
    sessionStorage.setItem('id', data._id);
    sessionStorage.setItem('email', data.email);

    window.location.href = 'http://127.0.0.1:5500/Remote%20Data%20and%20Authentication/05.Fisher-Game/src/index.html'
}

async function Login(email, password){
    const url = "http://localhost:3030/users/login";

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