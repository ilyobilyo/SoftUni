function search() {
   const towns = document.querySelectorAll('li');
   for (let i = 0; i < towns.length; i++) {
      towns[i].style.textDecoration = 'none';
      towns[i].style.fontWeight = 'normal';
   }
   const searchTerm = document.querySelector('#searchText').value;
   let matchesCount = 0;

   for (let i = 0; i < towns.length; i++) {
      if (towns[i].textContent.includes(searchTerm)) {
         matchesCount++;
         towns[i].style.textDecoration = 'underline';
         towns[i].style.fontWeight = 'bold';
      }
   }
   let result = `${matchesCount} matches found`
   document.querySelector('#result').textContent = result;
}