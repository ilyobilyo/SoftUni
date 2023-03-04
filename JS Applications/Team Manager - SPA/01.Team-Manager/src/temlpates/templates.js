import { html } from '../../node_modules/lit-html/lit-html.js';

export const navigation = (user) => html`
<a href="/teams" class="action">Browse Teams</a>
${user ? html `
            <a href="/myTeams" class="action">My Teams</a>
            <a href="/logout" class="action">Logout</a>`
        :html `
            <a href="/login" class="action">Login</a>
            <a href="/register" class="action">Register</a>`}
`;

export const homeTemplate = (token) => html`
<section id="home">
    <article class="hero layout">
        <img src="./assets/team.png" class="left-col pad-med">
        <div class="pad-med tm-hero-col">
            <h2>Welcome to Team Manager!</h2>
            <p>Want to organize your peers? Create and manage a team for free.</p>
            <p>Looking for a team to join? Browse our communities and find like-minded people!</p>
            ${token 
            ? html`<a href="/teams" class="action cta">Browse Teams</a>`
            : html`<a href="/register" class="action cta">Sign Up Now</a>`}
        </div>
    </article>
</section>
`;
