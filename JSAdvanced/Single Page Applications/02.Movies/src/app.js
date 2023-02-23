import { RenderLoginForm } from './login.js';
import { RenderHome } from './home.js';
import { RenderRegisterForm } from './register.js';
import { CheckUserNav, Logout } from './util.js';
import { render } from './dom.js';
import { RenderCreateMovie } from './create.js';
import { RenderDetails } from './details.js';
import { RenderEditView } from './edit.js';

document.querySelector('nav').addEventListener('click', onNavigate);


const sections = {
    'navbar': CheckUserNav,
    'Movies': RenderHome,
    'Login': RenderLoginForm,
    'Register': RenderRegisterForm,
    'Logout': Logout,
    'Add Movie': RenderCreateMovie,
    'Details': RenderDetails,
    'Edit': RenderEditView
}

CheckUserNav();
goto('Movies');

function onNavigate(e){
    if (e.target.tagName == 'A') {
        const view = e.target.textContent;
        if (goto(view)) {
            e.preventDefault();
        }
    }
}

function goto(viewName, ...params){
    const view = sections[viewName];

    if (typeof view == 'function') {
        view({goto, CheckUserNav, render, params});
        return true;
    }

    return false;
}
