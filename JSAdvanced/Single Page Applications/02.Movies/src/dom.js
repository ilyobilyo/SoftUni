export function render(section){
    const footer = document.querySelector('.page-footer');
    const fragment = document.createDocumentFragment();
    const nav = document.querySelector('.navbar');

    fragment.appendChild(nav);
    fragment.appendChild(section);
    fragment.appendChild(footer);

    document.querySelector('#container').replaceChildren(fragment);
}

export function fillAllMovies(movies){
    const list = document.querySelector('#movies-list');

    list.innerHTML = '';

    movies.forEach(m => {
        const li = document.createElement('li');

        const img = document.createElement('img');
        img.src = m.img;

        const title = document.createElement('h2');
        title.textContent = m.title;

        const detailsBtn = document.createElement('button');
        detailsBtn.textContent = 'Details';
        detailsBtn.dataset.id = m._id;

        li.appendChild(img);
        li.appendChild(title);
        li.appendChild(detailsBtn);

        list.appendChild(li);
    })
}

export function fillDetailsView(movie, likesCount, section){
    section.querySelector('.row h1').textContent = `Movie title: ${movie.title}`;
    section.querySelector('.row img').src = movie.img;
    section.querySelector('.row p').textContent = movie.description;
    fillLikes(section, likesCount);

    section.querySelectorAll('a').forEach(btn => {
        btn.dataset.id = movie._id
    });
}

export function fillLikes(section, likesCount){
    section.querySelector('.row span').textContent = `Liked ${likesCount}`;
}

export function fillEditView(movie, section){
    section.querySelector('input[name="title"]').value = movie.title;
    section.querySelector('textarea[name="description"]').value = movie.description;
    section.querySelector('input[name="img"]').value = movie.img;
}