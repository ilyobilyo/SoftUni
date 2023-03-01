import { html, render} from '../node_modules/lit-html/lit-html.js';
import { navigationGuest, navigationUser } from './template.js';

export function initialize(links){
    const nav = document.querySelector('nav');
    nav.addEventListener('click', onNavigate);

    const context = {
        goto,
        renderTemplate,
        updateNav,
        onNavigate
    }

    return context;

    function onNavigate(e){
        e.preventDefault();

        let target = e.target;

        if (target.tagName == 'IMG') {
            target = target.parentElement;
        }

        if (target.tagName == 'A') {
            const url = new URL(target.href);
            goto(url.pathname);
        }

    }

    function goto(pathname, ...params){
        const handler = links[pathname];
        if (typeof handler == 'function') {
            handler(context, params);
        }
    }

    function renderTemplate(root, html){
        render(html(), root);
    }

    function updateNav(){
        const token = sessionStorage.getItem('accessToken');

        if (token) {
            renderTemplate(nav, navigationUser);
        } else {
            renderTemplate(nav, navigationGuest);
        }
    }
}