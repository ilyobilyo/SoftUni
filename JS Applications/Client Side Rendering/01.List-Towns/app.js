import {
    html,
    render
} from '../node_modules/lit-html/lit-html.js';

const root = document.getElementById('root');
document.querySelector('.content').addEventListener('submit', onSubmit)

function onSubmit(e){
    e.preventDefault();

    const formData = new FormData(e.target);
    const {towns} = Object.fromEntries(formData);
    const townsArray = towns.split(', ');

    render(createTemplate(), root);
    render(townsArray.map(t => createItams(t)), root.querySelector('ul'));
}

const createTemplate = () => html`<ul></ul>`
const createItams = (town) => html`<li>${town}</li>`