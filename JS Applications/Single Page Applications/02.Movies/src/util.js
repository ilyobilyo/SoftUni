const userNavigationItams = document.querySelectorAll('.navbar .user');
const guestNavigationItams = document.querySelectorAll('.navbar .guest');
const ulNavigation = document.querySelector('.navbar-nav');
const addMovieBtn = document.getElementById('add-movie-button');

export function CheckUserNav() {
    if (sessionStorage.getItem('accessToken')) {
        userNavigationItams[0].querySelector('a').textContent = `Welcome, ${sessionStorage.getItem('email')}`;

        ulNavigation.replaceChildren(userNavigationItams[0], userNavigationItams[1]);
    } else {
        ulNavigation.replaceChildren(guestNavigationItams[0], guestNavigationItams[1]);
    }
}

export function Logout(inctx) {
    sessionStorage.clear();
    inctx.CheckUserNav();
    inctx.goto('Movies');
}

export function CheckHomeViewUserButtons() {
    if (!sessionStorage.getItem('accessToken')) {
        addMovieBtn.style.display = 'none';
    } else {
        addMovieBtn.style.display = 'block';
    }
}

export function CreateClickHandler(anchor, callback){
    anchor.addEventListener('click', callback);
}

export function CreateSubmitHandler(form, callback) {
    form.addEventListener('submit', onSubmit);

    function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        const formObj = Object.fromEntries(formData);

        e.target.reset();
        callback(formObj);
    }
}

