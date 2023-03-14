const url = 'http://localhost:3005/api/users'

export const getAll = async () => {
    const pagination = composePgaeUrl(1);

    const response = await fetch(url + pagination);
    const data = await response.json();

    return data.users;
}

export const getById = async (id) => {
    const response = await fetch(`${url}/${id}`);
    const data = await response.json();

    return data.user;
}

export const create = async (body) => {
    const response = await fetch(url, {
        method: 'post',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(body)
    });

    const data = await response.json();

    return data.user;
}

export const edit = async (id, body) => {
    const response = await fetch(`${url}/${id}`, {
        method: 'put',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(body)
    });

    const data = await response.json();

    return data.user;
}

export const del = async (id) => {
    await fetch(`${url}/${id}`, {
        method: 'delete'
    });
}

function composePgaeUrl(pageNumber){
    let url = `?page=${pageNumber}&limit=10`;

    return url;
}