import { logout } from "./api/authData.js";

export function getUserData(){
    return {
        id: sessionStorage.getItem('id'),
        username: sessionStorage.getItem('username'),
        accessToken: sessionStorage.getItem('accessToken'),
        email: sessionStorage.getItem('email')
    }
}

export function setActive(anchor){
    document.querySelectorAll('nav a').forEach(a => { a.classList.remove('active') });

    anchor.classList.add('active');
}


export function extractFormData(form){
    const formData = new FormData(form);
    const formObj = Object.fromEntries(formData);

    return formObj;
}

export async function onLogout(ctx){
    await logout();

    ctx.updateNav();
    ctx.page.redirect('/');
}

export function endOfPage(){
    return window.innerHeight + window.pageYOffset >= document.body.offsetHeight
}

export function composeUrl(page){
    let url = `?page=${page}`;

    return url
}