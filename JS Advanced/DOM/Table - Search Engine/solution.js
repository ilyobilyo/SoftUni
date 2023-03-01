function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const data = document.querySelectorAll('tr');
      for (let i = 2; i < data.length; i++) {
         data[i].classList.remove("select");
      }

      const searchTerm = document.querySelector('#searchField').value;
      for (let i = 2; i < data.length; i++) {
         if (data[i].textContent.includes(searchTerm)) {
            data[i].classList.add("select");
         }
      }
   }
}