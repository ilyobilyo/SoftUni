const host = 'http://localhost:3030/';

async function request(method, url, body) {
    let options = {
        method,
        headers: {}
    };

    if (body) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }

    try {
        const response = await fetch(host + url, options)

        if (response.ok == false) {
            const error = await response.json();
            throw Error(error.message);
        }

        if (response.status == 204) {
            return response.json();
        } else {
            return await response.json();
        }
        
    } catch (error) {
        alert(error.message)
    }
}

export const get = request.bind(null, 'get');
export const post = request.bind(null, 'post');
export const put = request.bind(null, 'put');
export const del = request.bind(null, 'delete');
