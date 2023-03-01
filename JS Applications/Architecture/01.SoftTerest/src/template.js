import {
    html, nothing
} from "../node_modules/lit-html/lit-html.js";

import { repeat } from '../node_modules/lit-html/directives/repeat.js';

export const navigationUser = () => html `
<div class="container">
    <a class="navbar-brand" href="/">
        <img src="./images/idea.png" alt="">
    </a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive"
        aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav ml-auto">
            <li class="nav-item active">
                <a class="nav-link" href="/Dashboard">Dashboard</a>
            </li>
            <li class="nav-item active">
                <a class="nav-link" href="/Create">Create</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Logout">Logout</a>
            </li>
        </ul>
    </div>
</div>
`;

export const navigationGuest = () => html `
<div class="container">
    <a class="navbar-brand" href="/">
        <img src="./images/idea.png" alt="">
    </a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive"
        aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav ml-auto">
            <li class="nav-item active">
                <a class="nav-link" href="/Dashboard">Dashboard</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Login">Login</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Register">Register</a>
            </li>
        </ul>
    </div>
</div>
`;

export const homeTemplate = () => html `
<div class="container home wrapper  my-md-5 pl-md-5">
    <div class="d-md-flex flex-md-equal ">
        <div class="col-md-5">
            <img class="responsive" src="./images/01.svg" />
        </div>
        <div class="home-text col-md-7">
            <h2 class="featurette-heading">Do you wonder if your idea is good?</h2>
            <p class="lead">Join our family =)</p>
            <p class="lead">Post your ideas!</p>
            <p class="lead">Find what other people think!</p>
            <p class="lead">Comment on other people's ideas.</p>
        </div>
    </div>
    <div class="bottom text-center">
        <a class="btn btn-secondary btn-lg " href="">Get Started</a>
    </div>
</div>
`;

export const registerTemplate = (onRegister, onNavigate) => html `
<div class="container home wrapper  my-md-5 pl-md-5">
    <div class="row-form d-md-flex flex-mb-equal ">
        <div class="col-md-4">
            <img class="responsive" src="./images/idea.png" alt="">
        </div>
        <form @submit=${onRegister} class="form-user col-md-7" action="" method="">
            <div class="text-center mb-4">
                <h1 class="h3 mb-3 font-weight-normal">Register</h1>
            </div>
            <div class="form-label-group">
                <label for="email">Email</label>
                <input type="text" id="email" name="email" class="form-control" placeholder="Email" required=""
                    autofocus="">
            </div>
            <div class="form-label-group">
                <label for="password">Password</label>
                <input type="password" id="password" name="password" class="form-control"
                    placeholder="Password" required="">
            </div>
            <div class="form-label-group">
                <label for="inputRepeatPassword">Repeat Password</label>
                <input type="password" id="inputRepeatPassword" name="repeatPassword" class="form-control"
                    placeholder="Repeat Password" required="">
            </div>
            <button class="btn btn-lg btn-dark btn-block" type="submit">Sign Up</button>
            <div class="text-center mb-4">
                <p class="alreadyUser"> Don't have account? Then just
                    <a @click=${onNavigate} href="/Login">Sign-In</a>!
                </p>
            </div>
            <p class="mt-5 mb-3 text-muted text-center">© SoftTerest - 2019.</p>
        </form>
    </div>
</div>
`;

export const loginTemplate = (onLogin, onNavigate) => html`
<div class="container home wrapper  my-md-5 pl-md-5">
    <div class="row-form d-md-flex flex-mb-equal ">
        <div class="col-md-4">
            <img class="responsive" src="./images/idea.png" alt="">
        </div>
        <form @submit=${onLogin} class="form-user col-md-7" action="" method="">
            <div class="text-center mb-4">
                <h1 class="h3 mb-3 font-weight-normal">Login</h1>
            </div>
            <div class="form-label-group">
                <label for="inputEmail">Email</label>
                <input type="text" id="inputEmail" name="email" class="form-control" placeholder="Email" required=""
                    autofocus="">
            </div>
            <div class="form-label-group">
                <label for="inputPassword">Password</label>
                <input type="password" id="inputPassword" name="password" class="form-control"
                    placeholder="Password" required="">
            </div>
            <div class="text-center mb-4 text-center">
                <button class="btn btn-lg btn-dark btn-block" type="submit">Sign In</button>
                <p class="alreadyUser"> Don't have account? Then just
                    <a @click=${onNavigate} href="/Register">Sign-Up</a>!
                </p>
            </div>
            <p class="mt-5 mb-3 text-muted text-center">© SoftTerest - 2019.</p>
        </form>
    </div>
</div>
`;

export const dashboardTemplate = (ideas, gotoDetails) => html`
<div id="dashboard-holder">
    ${ideas.length > 0 
    ? repeat(ideas, i => i._id, i => html`
        <div class="card overflow-hidden current-card details" style="width: 20rem; height: 18rem;">
            <div class="card-body">
                <p class="card-text">${i.title}</p>
            </div>
            <img class="card-image" src="${i.img}" alt="Card image cap">
            <a @click=${gotoDetails} data-id=${i._id} class="btn" href="/Details">Details</a>
        </div>
    `)
    : html`<h1>No ideas yet! Be the first one :)</h1>`}
</div>
`;

export const detailsTemplate = (idea, onDelete) => html`
    <div class="container home some">
        <img class="det-img" src=${idea.img} />
        <div class="desc">
            <h2 class="display-5">${idea.title}</h2>
            <p class="infoType">Description:</p>
            <p class="idea-description">${idea.description}</p>
        </div>
        <div class="text-center">
            ${sessionStorage.getItem('id') == idea._ownerId
            ? html`<a @click=${onDelete} data-id=${idea._id} class="btn detb" href="">Delete</a>`
            : nothing}
        </div>
    </div>
`;

export const createTemplate = (onCreate) => html`
    <div class="container home wrapper  my-md-5 pl-md-5">
        <div class=" d-md-flex flex-mb-equal ">
            <div class="col-md-6">
                <img class="responsive-ideas create" src="./images/creativity_painted_face.jpg" alt="">
            </div>
            <form @submit=${onCreate} class="form-idea col-md-5" action="#/create" method="post">
                <div class="text-center mb-4">
                    <h1 class="h3 mb-3 font-weight-normal">Share Your Idea</h1>
                </div>
                <div class="form-label-group">
                    <label for="ideaTitle">Title</label>
                    <input type="text" id="ideaTitle" name="title" class="form-control" placeholder="What is your idea?"
                        required="" autofocus="">
                </div>
                <div class="form-label-group">
                    <label for="ideaDescription">Description</label>
                    <textarea type="text" name="description" class="form-control" placeholder="Description"
                        required=""></textarea>
                </div>
                <div class="form-label-group">
                    <label for="inputURL">Add Image</label>
                    <input type="text" id="inputURL" name="imageURL" class="form-control" placeholder="Image URL"
                        required="">

                </div>
                <button class="btn btn-lg btn-dark btn-block" type="submit">Create</button>

                <p class="mt-5 mb-3 text-muted text-center">© SoftTerest - 2021.</p>
            </form>
        </div>
    </div>
`;