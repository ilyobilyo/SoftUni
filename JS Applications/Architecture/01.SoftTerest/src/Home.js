import { homeTemplate } from "./template.js";

const main = document.querySelector('main');

export function ShowHome(ctx){
    ctx.renderTemplate(main, homeTemplate)
}