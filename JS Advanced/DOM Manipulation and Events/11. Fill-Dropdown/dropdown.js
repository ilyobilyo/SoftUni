function addItem() {
    let text = document.getElementById('newItemText').value;
    let value = document.getElementById('newItemValue').value;

    let optionEl = document.createElement('option');
    optionEl.text = text;
    optionEl.value = value;

    document.getElementById('menu').appendChild(optionEl);

    document.getElementById('newItemText').value = '';
    document.getElementById('newItemValue').value = '';
}