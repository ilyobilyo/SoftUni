import { get, post } from "./api.js";

const endpoints = {
    'register': '/users/register',
    'login': '/users/login',
    'logout': '/users/logout',
}

export async function register(email, username, password){
    const resopnse = await post(endpoints.register, {email, username, password})

    sessionStorage.setItem('accessToken', resopnse.accessToken);
    sessionStorage.setItem('username', resopnse.username);
    sessionStorage.setItem('email', resopnse.email);
    sessionStorage.setItem('id', resopnse._id);

    return resopnse;
}

export async function login(email, password){
    const resopnse = await post(endpoints.login, {email, password})

    sessionStorage.setItem('accessToken', resopnse.accessToken);
    sessionStorage.setItem('username', resopnse.username);
    sessionStorage.setItem('email', resopnse.email);
    sessionStorage.setItem('id', resopnse._id);

    return resopnse;
}

export async function logout(){
    await get(endpoints.logout)

    sessionStorage.clear();
}