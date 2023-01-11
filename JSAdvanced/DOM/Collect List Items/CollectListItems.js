function extractText() {
    const items = document.getElementById('items');
    const arr = items.getElementsByTagName('li');
    let result = [];
    for(let item of arr){
        result.push(item.textContent);
    }
    document.getElementById('result').textContent = result.join('\n');
}