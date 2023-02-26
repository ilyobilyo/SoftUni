import {
    html,
    render,
    nothing
} from '../node_modules/lit-html/lit-html.js';
import {
    contacts
} from './contacts.js'

const main = document.querySelector('#contacts');

const template = (contact, toggleInfo) => html`
<div class="contact card">
    <div>
        <i class="far fa-user-circle gravatar"></i>
    </div>
    <div class="info">
        <h2>Name: ${contact.name}</h2>
        <button class="detailsBtn" @click=${toggleInfo.bind(null, contact)}>Details</button>

        ${contact.showDetails 
            ? html`<div class="details" id=${contact.id}>
                    <p>Phone number: ${contact.phoneNumber}</p>
                    <p>Email: ${contact.email}</p>
                </div>`
            : nothing}
    </div>
</div>`;

update();

function toggleInfo(contact) {
    contact.showDetails = !contact.showDetails;
    update();
}

function update(){
    render(contacts.map((c) => template(c, toggleInfo)), main);
}