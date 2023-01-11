function editElement(text, match, replacer) {
    let content = text.textContent;
    let pattern = new RegExp(match, 'g');
    let result = content.replace(pattern, replacer);
    text.textContent = result;
}