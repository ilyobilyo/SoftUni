function attachEvents() {
    document.querySelector('#refresh').addEventListener('click', GetAllComments);
    document.querySelector('#submit').addEventListener('click', CreateCommentHandler);
}

function Refresh(data){
    const allComments = Object.values(data).map(x => `${x.author}: ${x.content}`);
    
    document.querySelector('textarea').textContent = allComments.join('\n');
}

function CreateCommentHandler(){
    const authorInput = document.querySelector('input[name="author"]');
    const contentInput = document.querySelector('input[name="content"]');

    CreateComment(authorInput.value, contentInput.value);

    authorInput.value = "";
    contentInput.value = "";
}

async function GetAllComments(){
    const url = "http://localhost:3030/jsonstore/messenger";

    const response = await fetch(url);
    const data = await response.json();

    Refresh(data);
}

async function CreateComment(author, content){
    const url = "http://localhost:3030/jsonstore/messenger";

    const body = {
        author,
        content
    }

    const header = CreateHeader('post', body);

    const response = await fetch(url, header);
    GetAllComments();
}

function CreateHeader(method, body){
    return {
        method: method,
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(body)
    }
}

attachEvents();