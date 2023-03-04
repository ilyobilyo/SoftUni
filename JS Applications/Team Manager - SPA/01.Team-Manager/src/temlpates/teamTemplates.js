import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { repeat } from '../../node_modules/lit-html/directives/repeat.js';
import { composeUrl } from '../util.js'


export const browseTeamsTemplate = (items, page, totalPages, token) => html `
<section id="browse">

    <article class="pad-med">
        <h1>Team Browser</h1>
    </article>

    <article class="layout narrow">
        ${token? html`<div class="pad-small"><a href="/create" class="action cta">Create Team</a></div>` : nothing}
    </article>

    ${repeat(items, i => i._id, i => teamCardTemplate(i))}

    <div class="page-btn">
        ${page > 1 ? html`<a href=${composeUrl(page - 1)}>Prev</a>` : nothing}
        <p>${page}/${totalPages}</p>
        ${page < totalPages ? html`<a href=${composeUrl(page + 1)}>Next</a>` : nothing}
    </div>
</section>
`;

export const teamCardTemplate = (item) => html`
<article class="layout">
    <img src=${item.logoUrl} class="team-logo left-col">
    <div class="tm-preview">
        <h2>${item.name}</h2>
        <p>${item.description}</p>
        <span class="details">${item.membersCount} Members</span>
        <div><a href="/details/${item._id}" class="action">See details</a></div>
    </div>
</article>
`;

export const createTeamTemplate = (onSubmit, message) => html`
<section id="create">
    <article class="narrow">
        <header class="pad-med">
            <h1>New Team</h1>
        </header>
        <form @submit=${onSubmit} id="create-form" class="main-form pad-large">
            ${message ? html`<div class="error">${message}</div>` : nothing}
            <label>Team name: <input type="text" name="name"></label>
            <label>Logo URL: <input type="text" name="logoUrl"></label>
            <label>Description: <textarea name="description"></textarea></label>
            <input class="action cta" type="submit" value="Create Team">
        </form>
    </article>
</section>
`;

export const createDetailsTemplate = (team, currentUser, onJoin, onApprove, cancelMembership, owner) => html`
<section id="team-home">
    <article class="layout">
        <img src=${team.logoUrl} class="team-logo left-col">
        <div class="tm-preview">
            <h2>${team.name}</h2>
            <p>${team.description}</p>
            <span class="details">${team.members.length} Members</span>
            <div>
                ${currentUser.isOwner 
                    ? html`<a href="/edit/${team._id}" class="action">Edit team</a>`
                    : nothing}
                ${currentUser.isMember && !currentUser.isOwner 
                    ? html`<a @click=${cancelMembership} data-id=${team.members.find(x => x._ownerId == currentUser.id)._id} href="/${team._id}" class="action invert">Leave team</a>` 
                    : nothing}
                ${currentUser.isPending 
                    ? html`Membership pending. <a @click=${cancelMembership} data-id=${team.pendings.find(x => x._ownerId == currentUser.id)._id} href="/${team._id}">Cancel request</a>` 
                    : currentUser.isOwner || currentUser.isMember || !currentUser.accessToken
                    ? nothing 
                    : html`<a @click=${onJoin} href="/${team._id}" class="action">Join team</a>`}
            </div>
        </div>
        <div class="pad-large">
            <h3>Members</h3>
            <ul class="tm-members">
                ${repeat(team.members, i => i._id, i => membersTemplate(i, currentUser.isOwner, cancelMembership, owner))}
            </ul>
        </div>
        ${currentUser.isOwner 
            ? html`
                <div class="pad-large">
                    <h3>Membership Requests</h3>
                    <ul class="tm-members">
                        ${repeat(team.pendings, i => i._id, i => pendingTemplate(i, onApprove, cancelMembership))}
                    </ul>
                </div>`
            : nothing}
    </article>
</section>
`;

export const createEditTemplate = (team, onSubmit, message) => html`
<section id="edit">
    <article class="narrow">
        <header class="pad-med">
            <h1>Edit Team</h1>
        </header>
        <form @submit=${onSubmit} id="edit-form" class="main-form pad-large">
            ${message ? html`<div class="error">${message}</div>` : nothing}
            <label>Team name: <input type="text" name="name" value=${team.name}></label>
            <label>Logo URL: <input type="text" name="logoUrl" .value=${team.logoUrl}></label>
            <label>Description: <textarea name="description" .value=${team.description}></textarea></label>
            <input class="action cta" type="submit" value="Save Changes">
        </form>
    </article>
</section>
`;

export const createMyTeamsTemplate = (teams, page, totalPages) => html`
<section id="my-teams">
    <article class="pad-med">
        <h1>My Teams</h1>
    </article>

    ${teams.length == 0 
    ? html`
    <article class="layout narrow">
        <div class="pad-med">
            <p>You are not a member of any team yet.</p>
            <p><a href="/teams">Browse all teams</a> to join one, or use the button bellow to cerate your own
                team.</p>
        </div>
        <div class=""><a href="/create" class="action cta">Create Team</a></div>
    </article>`
    : repeat(teams, i => i._id, i => teamCardTemplate(i))}

    ${teams.length > 0
    ? html`
        <div class="page-btn">
            ${page > 1 ? html`<a href=${composeUrl(page - 1)}>Prev</a>` : nothing}
            <p>${page}/${totalPages}</p>
            ${page < totalPages ? html`<a href=${composeUrl(page + 1)}>Next</a>` : nothing}
        </div>
    `
    : nothing}
    
</section>`;


const membersTemplate = (member, isOwner, cancelMembership, owner) => html`
<li>${member.user.username}${isOwner && member._ownerId !== owner._id 
? html`<a data-id=${member._id} @click=${cancelMembership} href="/${member.teamId}" class="tm-control action">Remove from team</a>` 
: nothing}</li>
`

const pendingTemplate = (pending, onApprove, cancelMembership) => html`
<li>${pending.user.username}<a @click=${onApprove} href="/${pending.teamId}" data-id=${pending._id} class="tm-control action">Approve</a><a @click=${cancelMembership} href="/${pending.teamId}" data-id=${pending._id} class="tm-control action">Decline</a></li>
`