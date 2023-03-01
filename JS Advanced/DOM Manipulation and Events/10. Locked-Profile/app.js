function lockedProfile() {
    let btns = document.querySelectorAll('button');
    for (const btn of btns) {
        btn.addEventListener('click', onClick);
    }

    function onClick(e) {
        let isUnlock = e.target.parentElement.querySelector('input[value="unlock"]').checked;

        if (isUnlock) {
            const div = e.target.parentElement.querySelector('div')
            if (div.style.display == '') {
                div.style.display = 'inline';
                e.target.textContent = 'Hide it';
            } else {
                div.style.display = '';
                e.target.textContent = 'Show more';
            }
        }
    }
}