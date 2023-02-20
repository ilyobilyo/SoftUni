const main = document.querySelector('main');
const section = document.querySelector('.details');
const form = document.querySelector('.answer-comment form');
form.addEventListener('submit', onSubmit);

section.remove();

export function ShowDeatails(e) {
    let id = '';

    if (e.target.tagName == 'H2') {
        id = e.target.parentElement.id;
    } else {
        id = e.target.id;
    }

    RenderDetails(id);

    main.replaceChildren(section);
}

async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const formObj = Object.fromEntries(formData);
    const postId = e.target.querySelector('button').id;

    const data = await CreateComment(postId, formObj.username, formObj.postText);

    form.reset()

    RenderDetails(postId);
}

async function RenderDetails(id) {
    const post = await GetPost(id)
    const divComments = document.querySelector('.comment');

    divComments.innerHTML = `
    <div class="header">
        <img src="./static/profile.png" alt="avatar">
        <p>
            <span>${post.topicName}</span> posted on <time>${post.date}</time>
        </p>
        <p class="post-content">${post.postText}</p>
    </div>
    `

    document.querySelector('.theme-name h2').textContent = post.topicName;

    form.querySelector('button').setAttribute('id', id);

    const comments = await GetCommentsForPost(id);

    comments.forEach(c => {
        divComments.innerHTML += `
        <div id="user-comment">
            <div class="topic-name-wrapper">
                <div class="topic-name">
                    <p><strong>${c.username}</strong> commented on <time>${c.date}</time></p>
                    <div class="post-content">
                        <p>${c.postText}</p>
                    </div>
                </div>
            </div>
        </div>
        `
    })
}

async function CreateComment(postId, username, postText){
    const url = `http://localhost:3030/jsonstore/collections/myboard/comments`;

    const body = {
        username,
        date: new Date(),
        postText,
        postId
    };

    const response = await fetch(url, {
        method: 'post',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(body)
    });

    const data = await response.json();

    return data;
}

async function GetCommentsForPost(postId){
    const url = `http://localhost:3030/jsonstore/collections/myboard/comments`;

    const response = await fetch(url);
    const data = await response.json();

    const comments = Object.values(data).filter(x => x.postId == postId);

    return comments;
}

async function GetPost(id) {
    const url = `http://localhost:3030/jsonstore/collections/myboard/posts/${id}`;

    const response = await fetch(url);
    const data = await response.json();

    return data;
}