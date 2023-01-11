function toggle() {
    const buttonText = document.querySelector('.button').textContent;
    if(buttonText === 'More'){
        document.querySelector('#extra').style.display = 'block';
        document.querySelector('.button').textContent = 'Less';
    }else{
        document.querySelector('#extra').style.display = 'none';
        document.querySelector('.button').textContent = 'More';
    }
}