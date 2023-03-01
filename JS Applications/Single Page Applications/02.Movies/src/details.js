import {
    get,
    deleteMovie,
    post
} from './api.js'
import {
    fillDetailsView,
    fillLikes
} from './dom.js'
import {
    CreateClickHandler
} from './util.js';


const section = document.querySelector('#movie-example');

CreateClickHandler(section.querySelector('.btn-danger'), onDelete);
CreateClickHandler(section.querySelector('.btn-warning'), gotoEdit);
CreateClickHandler(section.querySelector('.btn-primary'), onLike);

section.remove();

let context = null;

export async function RenderDetails(inctx) {
    context = inctx;

    const movieId = context.params[0];
    const movie = await get('/data/movies/' + movieId);
    const likesCount = await getLikesCount(movieId);
    fillDetailsView(movie, likesCount, section);
    CheckDetailsViewUserButtons(movie._ownerId);
    context.render(section);
}


function CheckDetailsViewUserButtons(ownerId) {
    if (!sessionStorage.getItem('accessToken')) {
        section.querySelector('.btn-danger').style.display = 'none';
        section.querySelector('.btn-warning').style.display = 'none';
        section.querySelector('.btn-primary').style.display = 'none';
        return;
    }

    if (sessionStorage.getItem('id') !== ownerId) {
        section.querySelector('.btn-danger').style.display = 'none';
        section.querySelector('.btn-warning').style.display = 'none';
        if (alreadyLiked()) {
            section.querySelector('.btn-primary').style.display = 'none';
        } else {
            section.querySelector('.btn-primary').style.display = 'inline-block';
        }

    } else {
        section.querySelector('.btn-primary').style.display = 'none';
        section.querySelector('.btn-danger').style.display = 'inline-block';
        section.querySelector('.btn-warning').style.display = 'inline-block';
    }
}

function onDelete(e) {
    deleteMovie(`/data/movies/${e.target.dataset.id}`);

    context.goto('Movies');
}

function gotoEdit(e) {
    context.goto('Edit', e.target.dataset.id);
}

async function onLike(e) {
    if (!alreadyLiked()) {
        const like = await post('/data/likes', {
            movieId: context.params[0]
        });
        const likesCount = await getLikesCount(context.params[0]);
        fillLikes(section, likesCount);
    }

    section.querySelector('.btn-primary').style.display = 'none';
}

async function alreadyLiked() {
    const alreadyLiked = await get(`/data/likes?where=_ownerId%3D%22${sessionStorage.getItem('id')}%22`);

    if (alreadyLiked.length > 0) {
        return true;
    } else {
        return false;
    }
}

async function getLikesCount(movieId) {
    return await get(`/data/likes?where=movieId%3D%22${movieId}%22&&count`)
}