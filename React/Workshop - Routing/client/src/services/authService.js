import { get, post } from "../utils/requester"

export const register = (email, password) => {
    return post('/users/register', {email, password});
}

export const login = (email, password) => {
    return post('/users/login', {email, password});
}

export const logout = () => {
    return get('/users/logout');
}