function solve() {
   let products = [];
   let total = 0;

   let checkoutButton = document.querySelector('.checkout');
   let productContainers = document.querySelectorAll('.product');
   let textArea = document.querySelector('textarea');

   productContainers.forEach(container => {
      let addProductButton = container.querySelector('.add-product');

      addProductButton.addEventListener('click', function(e){
         let product = container.querySelector('.product-title').textContent;
         let price = parseFloat(container
            .querySelector('.product-line-price').textContent);
   
         if(!products.includes(product))
            products.push(product);

         total+=price;
   
         textArea.textContent += `Added ${product} for ${price.toFixed(2)} to the cart.\n`;
      });
   });

   checkoutButton.addEventListener('click', function(e){
      textArea.textContent += `You bought ${products.join(', ')} for ${total.toFixed(2)}.`;

      productContainers.forEach(container => {
         let addProductButton = container.querySelector('.add-product');
         addProductButton.disabled = true;
      });

      checkoutButton.disabled = true;
   });
}