import { del, get, post, put } from "../utils/requester";

export const GetAll = () => {
    return get('/data/games?sortBy=_createdOn%20desc');
}

export const GetLastThreeAddedGames = () => {
    return get('/data/games?sortBy=_createdOn%20desc&pageSize=3')
}

export const GetById = (id) => {
    return get(`/data/games/${id}`);
}

export const GetGameComments = (gameId) => {
    return get(`/data/comments?where=gameId%3D%22${gameId}%22`)
}

export const CreateGame = (body) => {
    return post('/data/games', body)
}

export const CreateComment = (body) => {
    return post('/data/comments', body)
}

export const EditGame = (gameId, body) => {
    return put(`/data/games/${gameId}`, body)
}

export const removeGame = (gameId) => {
    return del(`/data/games/${gameId}`)
}