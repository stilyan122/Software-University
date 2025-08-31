function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      let inputsContainer = document.getElementById('inputs');
      let bestRestaurantData = document.getElementById('bestRestaurant');
      let bestRestaurantWorkers = document.getElementById('workers');

      let bestRestaurantDataField = bestRestaurantData.getElementsByTagName('p')[0];
      let bestRestaurantWorkersField = bestRestaurantWorkers.getElementsByTagName('p')[0];

      let restaurantsInput = JSON.parse(inputsContainer
         .getElementsByTagName('textarea')[0].value);

      let restaurants = {};

      restaurantsInput.forEach(restaurantInput => {
         let [name, workersInput] = restaurantInput.split(' - ');
         let workers = workersInput.split(', ');

         if (restaurants[name]) {
            restaurants[name].push(...workers);
         } else {
            restaurants[name] = [...workers];
         }
      });
      
      let bestRestaurant = undefined;
      let bestAverageSalary = 0;
      let bestMaxSalary = 0;
      let bestWorkers = [];

      for (const element of Object.entries(restaurants)) {
         let workers = element[1]
            .map(w => parseFloat(w.split(' ')[1]));

         let averageSalary = workers.reduce((acc, curr) => acc + curr, 0) / workers.length;
         let maxSalary = Math.max(...workers);

         if (bestAverageSalary < averageSalary) {
            bestAverageSalary = averageSalary;
            bestRestaurant = element[0];
            bestMaxSalary = maxSalary;
            bestWorkers = element[1];
         }
      }

      bestRestaurantDataField.textContent = `Name: ${bestRestaurant} Average Salary: ${bestAverageSalary.toFixed(2)} Best Salary: ${bestMaxSalary.toFixed(2)}`;
   
      bestWorkers.sort((a, b) => 
         parseFloat(b.split(' ')[1]) - 
         parseFloat(a.split(' ')[1]));

      let output = bestWorkers
         .map(w => `Name: ${w.split(' ')[0]} With Salary: ${w.split(' ')[1]}`);
   
      bestRestaurantWorkersField.textContent = output.join(' ');
   }
}