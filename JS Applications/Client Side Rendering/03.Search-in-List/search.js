import { html, render } from '../node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

const townsDiv = document.getElementById('towns');
const resultDiv = document.getElementById('result');
document.querySelector('button').addEventListener('click', search)

const createUl = () => html`<ul></ul>`;
render(createUl(), townsDiv);

const createListItams = (town) => html`<li>${town}</li>`;
render(towns.map(t => createListItams(t)), townsDiv.querySelector('ul'));

const createResult = (count) => html`${count} matches found`;

function search(e) {
   let count = 0;
   const input = document.getElementById('searchText');

   const text = input.value;

   const liTowns = document.querySelectorAll('li');

   liTowns.forEach(t => {
      t.classList.remove('active');

      if (t.textContent.includes(text)) {
         t.classList.add('active');
         count++;
      }
   })

   render(createResult(count), resultDiv);

   input.value = '';
}
