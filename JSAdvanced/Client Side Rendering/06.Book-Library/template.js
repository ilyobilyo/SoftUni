import {html,render} from '../node_modules/lit-html/lit-html.js';
import {repeat} from '../node_modules/lit-html/directives/repeat.js';
import {styleMap} from '../node_modules/lit-html/directives/style-map.js';

const initTemplate = (renderAll, isEdit, book) => html`
<button id="loadBooks" @click=${renderAll}>LOAD ALL BOOKS</button>
    <table>
        <thead>
            <tr>
                <th>Title</th>
                <th>Author</th>
                <th>Action</th>
            </tr>
        </thead>
        
    </table>

    ${ isEdit ? editFormTemplate(book) : addFormTemplate }
`;

const tableRow = (books, edit, del) => html`
    <tbody>
        ${repeat(books, i => i.id, (i) => html `
        <tr>
            <td>${i.title}</td>
            <td>${i.author}</td>
            <td>
                <button @click=${edit} data-id=${i.id}>Edit</button>
                <button @click=${del} data-id=${i.id}>Delete</button>
            </td>
        </tr>
        `)}
    </tbody>
`;

const addFormTemplate = html`
    <form id="add-form">
        <h3>Add book</h3>
        <label>TITLE</label>
        <input type="text" name="title" placeholder="Title...">
        <label>AUTHOR</label>
        <input type="text" name="author" placeholder="Author...">
        <input type="submit" value="Submit">
    </form>
`;

const editFormTemplate = (book) => html `
    <form id="edit-form">
        <input type="hidden" name="id" value=${book.id}>
        <h3>Edit book</h3>
        <label>TITLE</label>
        <input type="text" name="title" placeholder="Title..." value=${book.title}>
        <label>AUTHOR</label>
        <input type="text" name="author" placeholder="Author..." value=${book.author}>
        <input type="submit" value="Save">
    </form>
`;

export function renderInit(renderAll){
    render(initTemplate(renderAll, false), document.body);
}

export function renderAllBooks(books, edit, del){
    render(tableRow(books, edit, del), document.querySelector('table'));
}

export function renderEdit(renderAll, book){
    render(initTemplate(renderAll, true, book), document.body);
}