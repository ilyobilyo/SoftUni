import {html,render} from '../node_modules/lit-html/lit-html.js';
import {repeat} from '../node_modules/lit-html/directives/repeat.js';

const select = document.getElementById('menu');
document.querySelector('input[type="submit"]').addEventListener('click', addItem);

const createOptions = (item) => html `<option value=${item._id}>${item.text}</option>`;

init();

function init(){
    GetAll();
}

async function GetAll(){
    const items = await request('get');

    update(items)
}

async function addItem(e) {
    e.preventDefault();
    const input = document.getElementById('itemText');

    const item = await request('post', {
        text: input.value
    });

    await GetAll();
}

async function request(method, body) {
    const url = 'http://localhost:3030/jsonstore/advanced/dropdown';

    let options = {
        method,
        headers: {}
    };

    if (body) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }

    try {
        const response = await fetch(url, options)

        if (response.ok == false) {
            const error = await response.json();
            throw Error(error.message);
        }

        return await response.json();
    } catch (error) {
        alert(error.message)
    }
}

function update(items){
    render(repeat(Object.values(items), i => i._id, i => createOptions(i)), select);
}