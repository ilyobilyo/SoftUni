import { ShowDeatails } from './details.js'

const main = document.querySelector('main');
const section = document.querySelector('.home');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);
const divTopicTitle = document.querySelector('.topic-title');
section.remove();

export function ShowHome() {
    RenderTopics();

    main.replaceChildren(section);
}

async function onSubmit(e) {
    e.preventDefault();

    if (e.submitter.textContent == 'Cancel') {
        form.reset();
        return;
    }

    const formData = new FormData(form);
    const formObj = Object.fromEntries(formData);

    if (formObj.topicName == '' || formObj.username == '' || formObj.postText == '') {
        form.reset();
        return;
    }

    const post = await CreatePost(formObj.topicName, formObj.username, formObj.postText);
    divTopicTitle.innerHTML += CreateTopicElement(post);

    form.reset();

    RenderTopics()
}

async function RenderTopics() {
    divTopicTitle.innerHTML = '';
    const allTopics = await GetAllTopics();

    allTopics.forEach(t => {
        const element = CreateTopicElement(t);
        divTopicTitle.innerHTML += element;
        document.querySelector('.normal').addEventListener('click', ShowDeatails);
    })

    const anchors = document.querySelectorAll('.normal');

    for (const link of anchors) {
        link.addEventListener('click', ShowDeatails);
    }
}

function CreateTopicElement(topic){
    const element = `
    <div class="topic-container">
        <div class="topic-name-wrapper">
            <div class="topic-name">
                <a href="#" id="${topic._id}" class="normal">
                    <h2>${topic.topicName}</h2>
                </a>
                <div class="columns">
                    <div>
                        <p>Date: <time>${topic.date}</time></p>
                        <div class="nick-name">
                            <p>Username: <span>${topic.username}</span></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    `;


    return element;
}

async function GetAllTopics(){
    const url = "http://localhost:3030/jsonstore/collections/myboard/posts";

    const response = await fetch(url);
    const data = await response.json();

    return Object.values(data);
}   

async function CreatePost(topicName, username, postText) {
    const url = "http://localhost:3030/jsonstore/collections/myboard/posts";

    const body = {
        topicName,
        username,
        postText,
        date: new Date()
    }

    const response = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    })

    const data = await response.json();

    return data;
}