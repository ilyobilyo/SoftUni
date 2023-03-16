import { post } from "../utils/requester"

export const register = (email, password) => {
    return post('/users/register', {email, password});
}