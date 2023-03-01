import { deleteIdea } from "./api.js";
import { GetById } from "./data.js";
import { detailsTemplate } from "./template.js";

const main = document.querySelector('main');

let context = null;

export async function ShowDetails(ctx, params){
    context = ctx;

    const idea = await GetById(params[0]);
    ctx.renderTemplate(main, detailsTemplate.bind(null, idea, onDelete))
}

async function onDelete(e){
    e.preventDefault();

    await deleteIdea(`/data/ideas/${e.target.dataset.id}`);
    context.goto('/Dashboard')
}