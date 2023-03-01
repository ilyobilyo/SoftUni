import { post, get, put, del } from "./api.js"

const endpoints = {
    'register': '/users/register',
    'login': '/users/login',
    'logout': '/users/logout',
    'createItem': '/data/catalog',
    'getAll': '/data/catalog',
    'byId': '/data/catalog/',
    'myCollection': '/data/catalog?where=_ownerId',
}

export async function register(email, password){
    const resopnse = await post(endpoints.register, {email, password})

    sessionStorage.setItem('accessToken', resopnse.accessToken);
    sessionStorage.setItem('email', resopnse.email);
    sessionStorage.setItem('id', resopnse._id);

    return resopnse;
}

export async function login(email, password){
    const resopnse = await post(endpoints.login, {email, password})

    sessionStorage.setItem('accessToken', resopnse.accessToken);
    sessionStorage.setItem('email', resopnse.email);
    sessionStorage.setItem('id', resopnse._id);

    return resopnse;
}

export async function logout(){
    await get(endpoints.logout)

    sessionStorage.clear();
}

export async function createItem(body){
    const resopnse = await post(endpoints.createItem, body);

    return resopnse;
}

export async function getAll(){
    const response = await get(endpoints.getAll);

    return response;
}

export async function getById(id){
    const response = await get(endpoints.byId + id);

    return response;
}

export async function update(id, body){
    const response = await put(endpoints.byId + id, body)

    return response;
}

export async function deleteItem(id){
    await del(endpoints.byId + id);
}

export async function GetMyItems(userId){
    const response = await get(endpoints.myCollection + `%3D%22${userId}%22`);

    return response;
}