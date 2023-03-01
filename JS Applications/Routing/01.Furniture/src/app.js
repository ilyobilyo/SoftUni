import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';
import { ShowCreate } from './views/create.js';
import { ShowDashboard } from './views/dashboard.js';
import { onDelete } from './views/delete.js';
import { ShowDetails } from './views/details.js';
import { ShowEdit } from './views/edit.js';
import { ShowLogin } from './views/login.js';
import { onLogout } from './views/logout.js';
import { ShowMyCollection } from './views/myFurniture.js';
import { ShowRegister } from './views/register.js';

const root = document.querySelector('.container');

page(renderMiddleware);
page('/', ShowDashboard);
page('/register', ShowRegister);
page('/login', ShowLogin);
page('/details/:id', ShowDetails);
page('/edit/:id', ShowEdit);
page('/myFurniture', ShowMyCollection);
page('/create', ShowCreate);
page('/logout', onLogout);
page('/delete/:id', onDelete);


updateNav();
page.start();

function renderMiddleware(ctx, next){
    ctx.render = (content) => render(content, root);
    ctx.updateNav = updateNav;

    if (ctx.pathname == '/') {
        setActive(document.getElementById('catalogLink'))
    } else if (ctx.pathname == '/register'){
        setActive(document.getElementById('registerLink'))
    } else if (ctx.pathname == '/login'){
        setActive(document.getElementById('loginLink'))
    } else if (ctx.pathname == '/myFurniture'){
        setActive(document.getElementById('profileLink'))
    } else if (ctx.pathname == '/create'){
        setActive(document.getElementById('createLink'))
    } 

    next();
}

function updateNav(){
    const token = sessionStorage.getItem('accessToken');
    const userDiv = document.getElementById('user');
    const guestDiv = document.getElementById('guest');

    if (token) {
        userDiv.style.display = 'inline-block';
        guestDiv.style.display = 'none';
    } else {
        userDiv.style.display = 'none';
        guestDiv.style.display = 'inline-block';
    }
}

function setActive(anchor){
    document.querySelectorAll('nav a').forEach(a => { a.classList.remove('active') });

    anchor.classList.add('active');
}