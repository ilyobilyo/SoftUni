function solve() {
  const data = document.querySelector('#input').value;
  const sentences = data.split('.').filter((p) => p.length > 0);
  let count = 0;
  let result = [];
  const element = document.getElementById('output');
  for (let i = 0; i < sentences.length; i++) {

    if (count >= 3) {
      let para = document.createElement('p');
      let text = document.createTextNode(`${result.join('. ')}.`);
      para.appendChild(text);
      element.appendChild(para);
      count = 0;
      result = [];
    }
    result.push(sentences[i]);
    count++;

    if(i === sentences.length - 1){
      let para = document.createElement('p');
      let text = document.createTextNode(`${result.join('. ')}.`);
      para.appendChild(text);
      element.appendChild(para);
    }
  }
}
