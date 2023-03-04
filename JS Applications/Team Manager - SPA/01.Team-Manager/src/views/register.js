import { register } from "../api/authData.js";
import { registerTemplate } from "../temlpates/authTemplates.js";
import { extractFormData } from "../util.js";

let context = null;

export function ShowRegister(ctx){
    if (!context) {
        context = ctx;
    }

    ctx.render(registerTemplate(onSubmit, context.params.message));

    if (context.params.message) {
        context.params.message = null
    }
}


async function onSubmit(e){
    e.preventDefault();

    const {email, username, password, repass} = extractFormData(e.target);

    if (email == '') {
        context.params.message = 'Email is required'
        ShowRegister(context)
        return;
    }

    if (username.length < 3 ) {
        context.params.message = 'Username must be at least 3 characters'
        ShowRegister(context)
        return;
    }

    if (password.length < 3) {
        context.params.message = 'Password must be at least 3 characters/digits'
        ShowRegister(context)
        return;
    }

    if (password !== repass) {
        context.params.message = 'Password and Repeat are not equal';
        ShowRegister(context);
        return;
    }

    try {
        const response = await register(email, username, password);
        e.target.reset();
    } catch (error) {
        context.params.message =  error.message
        ShowRegister(context);
        return;
    }


    context.updateNav();
    context.page.redirect('/myTeams');
}
