import { post } from './api.js';
import {CreateSubmitHandler} from './util.js'

CreateSubmitHandler(document.querySelector('#register-form'), onRegister);

const section = document.querySelector('#form-sign-up');
section.remove();

let context = null;

export function RenderRegisterForm(inctx) {
    context = inctx;
    inctx.render(section);
}


async function onRegister({email, password, repeatPassword}) {
    if (email == '' ||
        password.length < 6 ||
        password !== repeatPassword) {
            
        alert('All fields are required and password must be at least 6 characters');
        return;
    }

    const responseRegister = await post('/users/register', {email, password});

    sessionStorage.setItem('accessToken', responseRegister.accessToken);
    sessionStorage.setItem('email', responseRegister.email);
    sessionStorage.setItem('id', responseRegister._id);

    context.CheckUserNav();
    context.goto('Movies');
}
