import { post } from "./api.js";
import { registerTemplate } from "./template.js";
import { extractFormData } from "./util.js";

const main = document.querySelector('main');

let context = null;

export function ShowRegister(ctx){
    context = ctx;

    ctx.renderTemplate(main, registerTemplate.bind(null, onRegister, ctx.onNavigate))
}

async function onRegister(e) {
    e.preventDefault();

    const {email, password, repeatPassword} = extractFormData(e.target);

    if (email.length < 3 || password.length < 3) {
        alert('Email or password must be at least 3 characters long');
        return;
    }

    if (password !== repeatPassword) {
        alert('Password and Confirm Password are not equal');
        return;
    }

    const responseRegister = await post('/users/register', { email, password });

    sessionStorage.setItem('accessToken', responseRegister.accessToken);
    sessionStorage.setItem('email', responseRegister.email);
    sessionStorage.setItem('id', responseRegister._id);

    context.updateNav();
    context.goto('/');
}