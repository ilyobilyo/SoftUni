function addItem() {
    const item = document.querySelector('#newItemText').value;

    const element = document.querySelector('#items');
    const newItemElement = document.createElement('li');
    newItemElement.textContent = item;

    element.appendChild(newItemElement);
    document.querySelector('#newItemText').value = '';
}