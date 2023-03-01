import {
   html,
   render
} from '../node_modules/lit-html/lit-html.js';

async function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   const tbody = document.querySelector('tbody');

   const persons = await GetAll();

   const createRow = (person) => html `
   <tr>
       <td>${person.firstName} ${person.lastName}</td>
       <td>${person.email}</td>
       <td>${person.course}</td>
   </tr>`;

   update();

   function onClick(e) {
      clearClasses();
      const input = document.getElementById('searchField');
      const tableData = document.querySelectorAll('tbody td');

      const searchTerm = input.value.toLowerCase();

      tableData.forEach(d => {
         if (d.textContent.toLowerCase().includes(searchTerm)) {
            d.parentElement.classList.add('select');
         }

      })

      input.value = '';
   }

   function clearClasses(){
      const rows = document.querySelectorAll('tbody tr');
      rows.forEach(r => {
         r.classList.remove('select');
      })
   }

   async function GetAll() {
      const url = 'http://localhost:3030/jsonstore/advanced/table';

      try {
         const response = await fetch(url)

         if (response.ok == false) {
            const error = await response.json();
            throw Error(error.message);
         }

         return await response.json();
      } catch (error) {
         alert(error.message)
      }
   }

   function update(){
      render(Object.values(persons).map(p => createRow(p)), tbody);
   }
}

solve();