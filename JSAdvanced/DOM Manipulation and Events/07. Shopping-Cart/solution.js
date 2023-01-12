function solve() {
   const buttons = document.querySelectorAll('.add-product');
   for (let btn of buttons) {
      btn.addEventListener('click', addProduct);
   }

   document.querySelector('.checkout')
      .addEventListener('click', checkout);

   let cart = [];

   function checkout(e){
      let sum = 0;
      let prodNames = [];
      for(let prod of cart){
         sum += Object.values(prod)[0];
         prodNames.push(Object.keys(prod)[0])
      }

      document.querySelector('textarea').value += `You bought ${prodNames.join(', ')} for ${sum.toFixed(2)}.`;
      const btns = document.querySelectorAll('button');
      for (let btn of btns) {
         btn.disabled = true;
      }
   }


   function addProduct(e) {
      let prod = {};
      const productName = e.target
         .parentElement
         .parentElement
         .querySelector('.product-title')
         .textContent;
      const productPrice = e.target
         .parentElement
         .parentElement
         .querySelector('.product-line-price')
         .textContent;

      if (cart.some(x => x[productName] !== undefined)) {
         let currProd = cart.find(x => x[productName]);
         currProd[productName] += Number(productPrice);
      } else {
         prod[productName] = Number(productPrice);

         cart.push(prod);
      }

      document.querySelector('textarea').value += `Added ${productName} for ${productPrice} to the cart.\n`
   }
}