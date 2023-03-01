document.querySelector('#loadBooks').addEventListener('click', GetAllBooks);
document.querySelector('form').addEventListener('submit', CreateBook);
const url = "http://localhost:3030/jsonstore/collections/books";

function LoadAllBooks(books) {
    const tbody = document.querySelector('tbody');
    tbody.innerHTML = '';

    const ids = Object.keys(books);
    const data = Object.values(books)

    for (let i = 0; i < data.length; i++) {
        const tr = document.createElement('tr');

        const tdTitle = document.createElement('td');
        tdTitle.textContent = data[i].title;

        const tdAuthor = document.createElement('td');
        tdAuthor.textContent = data[i].author;

        const tdButtons = document.createElement('td');

        const editBtn = document.createElement('button');
        editBtn.textContent = 'Edit';
        editBtn.dataset.id = ids[i];
        editBtn.addEventListener('click', EditForm);

        const delBtn = document.createElement('button');
        delBtn.textContent = 'Delete';
        delBtn.dataset.id = ids[i];
        delBtn.addEventListener('click', DeleteBook);

        tdButtons.appendChild(editBtn);
        tdButtons.appendChild(delBtn);

        tr.appendChild(tdTitle);
        tr.appendChild(tdAuthor);
        tr.appendChild(tdButtons);

        tbody.appendChild(tr);
        
    }

}

function CreateBook(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const bookData = Object.fromEntries(formData.entries());
    debugger
    if (e.target.querySelector('button').textContent == 'Save') {
        const id = e.target.querySelector('button').dataset.id;

        if (bookData.title !== '' &&
        bookData.title !== undefined &&
        bookData.author !== ''  &&
        bookData.author !== undefined
        ) {
            Edit(id, bookData.title, bookData.author);
            e.target.reset();
            e.target.querySelector('h3').textContent = 'FORM';
            e.target.querySelector('button').textContent = 'Submit';
        }
    }else{
        if (bookData.title !== '' &&
        bookData.title !== undefined &&
        bookData.author !== ''  &&
        bookData.author !== undefined) {
            Create(bookData.title, bookData.author);
            e.target.reset();
        }
    }
   
}

async function EditForm(e){
    const form = document.querySelector('form');

    form.querySelector('h3').textContent = 'Edit FORM';

    const formBtn = form.querySelector('button');
    formBtn.textContent = 'Save';
}

function DeleteBook(e){
    Delete(e.target.dataset.id);
    e.target.parentElement.parentElement.remove();
}

async function GetBook(id){
    const response = await fetch(url + '/' + id);
    const data = await response.json();

    return data;
}

async function GetAllBooks() {
    const response = await fetch(url);
    const data = await response.json();

    LoadAllBooks(data);
}

async function Create(title, author) {
    const body = {
        author,
        title
    }

    const response = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    });
    const data = await response.json();
    GetAllBooks()
}

async function Edit(id, title, author){
    const body = {
        author,
        title
    };

    const response = await fetch(url + '/' + id, {
        method: 'put',
        headers: {'Content-Type': 'application/json' },
        body: JSON.stringify(body)
    });
    const data = await response.json();
    GetAllBooks()
}

async function Delete(id){
    const response = await fetch(url + '/' + id, {
        method: 'delete',
        headers: {'Content-Type': 'application/json' },
    })
    const data = await response.json();
    GetAllBooks()
}