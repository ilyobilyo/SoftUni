const host = 'http://localhost:3030';

async function request(url, method, body) {
    const options = {
        method,
        headers: {}
    }

    if (body !== undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }

    const token = sessionStorage.getItem('accessToken');

    if (token) {
        options.headers['X-Authorization'] = token;
    }

    try {
        const response = await fetch(host + url, options)

        if (response.ok == false) {
            const error = await response.json();
            throw Error(error.message);
        }

        if (response.status == 204) {
            return response
        } else {
            return await response.json();
        }

    } catch (error) {
        alert(error.message)
        throw new Error(error.message)
    }

}

export async function get(url){
    return request(url, 'get');
}

export async function post(url, body){
    return request(url, 'post', body);
}

export async function deleteIdea(url){
    return request(url, 'delete');
}