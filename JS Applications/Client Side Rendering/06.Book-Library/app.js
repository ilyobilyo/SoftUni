import {
    get,
    post,
    put,
    del
} from './api.js';
import {
    renderInit,
    renderAllBooks,
    renderEdit
} from './template.js'

function init() {
    renderInit(renderAll);

    document.getElementById('add-form').addEventListener('submit', onSubmit)
}

async function renderAll(e) {
    const books = await GetAll();

    renderAllBooks(books, edit, Del);
}

async function edit(e) {
    const book = await GetById(e.target.dataset.id);

    book.id = e.target.dataset.id;

    renderEdit(renderAll, book);

    document.getElementById('edit-form')
        .addEventListener('submit', onSubmit);
}

async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const updatedBook = Object.fromEntries(formData);

    if (updatedBook.title == "" || updatedBook.author == "") {
        alert('All fields are reqired!')
    } else if (e.submitter.value == 'Save') {
        await Update(updatedBook);
        init();
        renderAll();
    } else {
        await Create(updatedBook);
        renderAll();
        e.target.reset();
    }
}

async function GetAll() {
    const rawBooks = await get('jsonstore/collections/books');

    const processedBooks = [];

    for (const book of Object.entries(rawBooks)) {
        let obj = {
            id: book[0],
            title: book[1]['title'],
            author: book[1]['author']
        }

        processedBooks.push(obj);
    }

    return processedBooks;
}

async function GetById(id) {
    return await get(`jsonstore/collections/books/${id}`);
}

async function Create(body){
    return await post(`jsonstore/collections/books`, body);
}

async function Update(body) {
    return await put(`jsonstore/collections/books/${body.id}`, body);
}

async function Del(e) {
    await del(`jsonstore/collections/books/${e.target.dataset.id}`);
    renderAll();
}

init();