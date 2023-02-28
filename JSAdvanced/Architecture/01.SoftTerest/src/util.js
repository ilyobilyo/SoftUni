import { get } from "./api.js";

export function extractFormData(form){
    const formData = new FormData(form);
    const formObj = Object.fromEntries(formData);

    form.reset();
    return formObj;
}

export async function Logout(ctx){
    const responseLogout = await get('/users/logout');
    
    sessionStorage.clear();
    ctx.updateNav();
    ctx.goto('/');
}