import {
    get
} from "./api.js";
import {
    fillAllMovies
} from "./dom.js";
import {
    CheckHomeViewUserButtons,
    CreateClickHandler
} from "./util.js";

CreateClickHandler(document.getElementById('add-movie-button'), goToCreate)

const section = document.querySelector('#home-page');
section.remove();

let context = null;

export async function RenderHome(inctx) {
    context = inctx;

    CheckHomeViewUserButtons();
    inctx.render(section);
    const movies = await get('/data/movies');
    fillAllMovies(movies);
    addEventsForDetails();
}

function addEventsForDetails() {
    const itams = document.querySelectorAll('#movies-list li');

    itams.forEach(m => {
        CreateClickHandler(m.children[2], goToDetails)
    })
}

function goToCreate(e) {
    if (e.target.tagName == 'A') {
        context.goto('Add Movie');
    }
}

function goToDetails(e) {
    context.goto('Details', e.target.dataset.id);
}