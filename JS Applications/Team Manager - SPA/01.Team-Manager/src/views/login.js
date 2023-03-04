import { login } from "../api/authData.js";
import { loginTemplate } from "../temlpates/authTemplates.js";
import { extractFormData } from "../util.js";


let context = null;

export function ShowLogin(ctx){
    if (!context) {
        context = ctx;
    }

    ctx.render(loginTemplate(onSubmit, context.params.message))
    
    if (context.params.message) {
        context.params.message = null
    }
}

async function onSubmit(e){
    e.preventDefault();

    const {email, password} = extractFormData(e.target);

    if (email == '' || password == '') {
        context.params.message = 'All fields are required'
        ShowLogin(context);
        return;
    }

    try {
        const response = await login(email, password);
        e.target.reset();
    } catch (error) {
        context.params.message = error.message;
        ShowLogin(context);
        return;
    }

    context.updateNav();
    context.page.redirect('/myTeams');
}