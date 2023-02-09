function attachEvents() {
    const postsUrl = 'http://localhost:3030/jsonstore/blog/posts';
    const commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';

    const select = document.querySelector('#posts');

    document.querySelector('#btnLoadPosts').addEventListener('click', loadPosts);
    document.querySelector('#btnViewPost').addEventListener('click', viewPost);

    async function viewPost(e){
        const postResponse = await fetch(postsUrl + '/' + select.value);
        const postData = await postResponse.json();

        const commentsReponse = await fetch(commentsUrl);
        const commentsData = await commentsReponse.json();

        const commentsArr = Object.values(commentsData).filter(x => x.postId == postData.id);

        document.querySelector('#post-title').textContent = postData.title;
        document.querySelector('#post-body').textContent = postData.body;

        const ul = document.querySelector('#post-comments');

        ul.innerHTML = "";

        for (const comment of commentsArr) {
            const li = document.createElement('li');
            li.id = comment.id;
            li.textContent = comment.text;

            ul.appendChild(li);
        }
    }


    async function loadPosts(e){
        select.innerHTML = "";

        const response = await fetch(postsUrl);
        const posts = await response.json();

        const postsArr = Object.values(posts);

        for (const post of postsArr) {
            CreateOption(post);
        }
    }

    function CreateOption(post){
        const option = document.createElement('option');
        option.value = post.id;
        option.textContent = post.title;

        select.appendChild(option);
    }
}

attachEvents();