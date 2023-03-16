import { get } from "../utils/requester";

const baseUrl = 'http://localhost:3030';


export const GetAll = () => {
    return get('/data/games')
}