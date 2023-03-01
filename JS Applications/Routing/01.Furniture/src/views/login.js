import { login } from "../api/data.js";
import { loginTemplate } from "../templates/authTemplates.js";
import { extractFormData } from "../util.js";

let context = null;

export function ShowLogin(ctx){
    context = ctx;

    ctx.render(loginTemplate(onSubmit));
}

async function onSubmit(e){
    e.preventDefault();

    const {email, password} = extractFormData(e.target);

    if (email == '' || password == '') {
        alert('All fields are required');
        return;
    }

    const response = await login(email, password);

    context.updateNav();
    context.page.redirect('/');
}