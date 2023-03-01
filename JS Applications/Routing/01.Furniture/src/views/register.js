import { register } from "../api/data.js";
import { registerTemplate } from "../templates/authTemplates.js";
import { extractFormData } from "../util.js";

let context = null;

export function ShowRegister(ctx){
    context = ctx;

    ctx.render(registerTemplate(onSubmit));
}

async function onSubmit(e){
    e.preventDefault();

    const {email, password, rePass} = extractFormData(e.target);

    if (email == '' || password == '' || rePass == '') {
        alert('All fields are required');
        return;
    }

    if (password !== rePass) {
        alert('Password and Repeat are not equal');
        return;
    }

    const response = await register(email, password);

    context.updateNav();
    context.page.redirect('/');
}