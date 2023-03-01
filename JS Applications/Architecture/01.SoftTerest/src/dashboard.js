import { GetAll } from "./data.js";
import { dashboardTemplate } from "./template.js";

const main = document.querySelector('main');

let context = null;

export async function ShowDashboard(ctx){
    context = ctx;
    const allIdeas = await GetAll();

    ctx.renderTemplate(main, dashboardTemplate.bind(null, allIdeas, gotoDetails));
}

function gotoDetails(e){
    e.preventDefault();

    context.goto('/Details', e.target.dataset.id);
}