function create(words) {
   const divContent = document.getElementById('content');

   for (const word of words) {
      let div = document.createElement('div');
      let para = document.createElement('p');
      div.addEventListener('click', showPara);

      para.textContent = word;
      para.style.display = 'none';

      div.appendChild(para);

      divContent.appendChild(div);
   }

   function showPara(e){
      e.target.children[0].style.display = 'block';
   }
}