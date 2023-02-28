import { post } from "./api.js";
import { loginTemplate } from "./template.js";
import { extractFormData } from "./util.js";

const main = document.querySelector('main');

let context = null;

export function ShowLogin(ctx){
    context = ctx;

    ctx.renderTemplate(main, loginTemplate.bind(null, onLogin, ctx.onNavigate));
}

async function onLogin(e){
    e.preventDefault();

    const { email, password } = extractFormData(e.target);

    if (email == '' || password == '') {
        alert('All fields are required');
        return;
    }

    const loginResponse = await post('/users/login', { email, password });

    sessionStorage.setItem('accessToken', loginResponse.accessToken);
    sessionStorage.setItem('email', loginResponse.email);
    sessionStorage.setItem('id', loginResponse._id);

    context.updateNav();
    context.goto('/');
}