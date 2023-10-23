function solve() {
   const area = document.getElementsByTagName('textarea')[0];
   const buttons = Array.from(document.getElementsByClassName('add-product'));
   let products = new Set();
   let totalPrice = 0.0;
   buttons.forEach((btn)=>{
      btn.addEventListener('click',function() {
         const name = btn
         .parentElement
         .parentElement
         .getElementsByClassName('product-title')[0]
         .textContent;
         const price = Number(btn
            .parentElement
            .parentElement
            .getElementsByClassName('product-line-price')[0].textContent);
         products.add(name);
         totalPrice+= price;
         area.textContent+= `Added ${name} for ${price.toFixed(2)} to the cart.\n`;
      })
   });
   const checkout = document.getElementsByClassName('checkout')[0];
   checkout.addEventListener('click',function(){
      area.textContent+=`You bought ${Array.from(products).join(', ')} for ${totalPrice.toFixed(2)}.`;
      buttons.forEach((btn)=>{
         btn.disabled = true;
      });
      checkout.disabled = true;
   });
}