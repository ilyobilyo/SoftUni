import {
    post
} from './api.js';
import {
    CreateSubmitHandler
} from './util.js'

CreateSubmitHandler(document.querySelector('#form-login'), onLogin);

const section = document.querySelector('#form-login');
section.remove();

let context = null;

export function RenderLoginForm(inctx) {
    context = inctx;
    inctx.render(section);
}

async function onLogin({
    email,
    password
}) {
    if (email == '' ||
        password.length < 6) {
        alert('All fields are required');
        return;
    }

    const responseLogin = await post('/users/login', {email, password});

    sessionStorage.setItem('accessToken', responseLogin.accessToken);
    sessionStorage.setItem('email', responseLogin.email);
    sessionStorage.setItem('id', responseLogin._id);

    context.CheckUserNav();
    context.goto('Movies');
}