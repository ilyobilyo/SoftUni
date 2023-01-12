function addItem() {
    const item = document.querySelector('#newItemText').value;

    const element = document.querySelector('#items');

    const newItemElement = document.createElement('li');
    newItemElement.textContent = item;

    const anchor = document.createElement('a');
    anchor.href = '#';
    anchor.textContent = '[Delete]';
    anchor.addEventListener('click', DeleteItem)

    newItemElement.appendChild(anchor);
    element.appendChild(newItemElement);
    

    document.querySelector('#newItemText').value = '';

    function DeleteItem(ev){
        ev.target.parentNode.remove();
    }
}