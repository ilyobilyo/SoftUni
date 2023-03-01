import { get } from "./api.js";

export async function GetAll(){
    return await get('/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc');
}

export async function GetById(id){
    return await get(`/data/ideas/${id}`);
}