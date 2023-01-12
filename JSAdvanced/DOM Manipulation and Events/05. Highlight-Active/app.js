function focused() {
    const inputFields = document.querySelectorAll('input');
    for(let inp of inputFields){
        inp.addEventListener('focus', onFocus);
        inp.addEventListener('blur', onBlur);
    }

    function onFocus(e){
        e.target.parentElement.classList.add('focused');
    }

    function onBlur(e){
        e.target.parentElement.classList.remove('focused');
    }
}