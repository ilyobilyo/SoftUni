import { post } from "./api.js";
import { createTemplate } from "./template.js";
import { extractFormData } from "./util.js";

const main = document.querySelector('main');

let context = null;

export function ShowCreate(ctx){
    context = ctx;

    ctx.renderTemplate(main, createTemplate.bind(null, onCreate))
}

async function onCreate(e){
    e.preventDefault();

    const {title, description, imageURL} = extractFormData(e.target);

    if (title.length < 6) {
        alert('Title should be at least 6 characters long');
        return;
    } else if (description.length < 10) {
        alert('Description should be at least 10 characters long');
        return;
    } else if (imageURL.length < 5){
        alert('Image should be at least 5 characters long');
        return;
    }

    const createResponse = await post('/data/ideas', {title, description, imageURL});

    context.goto('/Dashboard');
}