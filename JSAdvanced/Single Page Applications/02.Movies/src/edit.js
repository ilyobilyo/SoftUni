import { put, get } from './api.js'
import { fillEditView } from './dom.js';
import { CreateSubmitHandler } from './util.js';


const section = document.querySelector('#edit-movie');
CreateSubmitHandler(section, onEdit);
section.remove();

let context = null;

export async function RenderEditView(inctx){
    context = inctx;

    const movieId = context.params[0];
    const movie = await get('/data/movies/' + movieId);
    fillEditView(movie, section);
    context.render(section);
}

async function onEdit({
    title,
    description,
    img
}) {
    if (title == '' || description == '' || img == '') {
        alert('All fields are required!');
        return;
    }

    const movie = await put('/data/movies/' + context.params[0], {
        title,
        description,
        img
    });

    context.goto('Details', movie._id);
}