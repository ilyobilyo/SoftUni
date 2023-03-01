import { post } from './api.js';
import {CreateSubmitHandler} from './util.js'

CreateSubmitHandler(document.querySelector('#add-movie-form'), onCreate);

const section = document.querySelector('#add-movie');
section.remove();

let context = null;

export function RenderCreateMovie(inctx) {
    context = inctx;
    context.render(section);
}

async function onCreate({
    title,
    description,
    img
}) {
    if (title == '' || description == '' || img == '') {
        alert('All fields are required!');
        return;
    }

    const movie = await post('/data/movies', {
        title,
        description,
        img
    });

    context.goto('Movies');
}