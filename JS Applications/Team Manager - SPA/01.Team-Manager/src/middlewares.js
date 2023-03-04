import { render } from "../node_modules/lit-html/lit-html.js";
import { navigation } from "./temlpates/templates.js";
import { getUserData } from "./util.js";

const root = document.querySelector('main');

export function renderMiddleware(ctx, next){
    ctx.render = (content) => render(content, root);
    ctx.updateNav = updateNav;

    next();
}

export function setUserMiddleware(ctx, next){
    ctx.user = getUserData();

    next();
}

export function queryParseMiddleware(ctx, next){
    ctx.query = {};

    if (ctx.querystring) {
        const query = Object.fromEntries(ctx.querystring.split('&').map(e => e.split('=')));

        Object.assign(ctx.query, query);
    }

    next();
}

export function updateNav(){
    const username = sessionStorage.getItem('username');
    const nav = document.querySelector('nav');

    render(navigation(username), nav);
}