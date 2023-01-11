function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      const allRest = document.querySelector('textarea').value;
      const allRestorants = allRest.split('"').filter(x => x.length > 3);

      let bestRest = '';
      let highestSalary = 0;
      let bestSalary = 0;
      let bestResWorkers = [];
      let restaurantsObjs = [];

      for (let rest of allRestorants) {
         const resData = rest.split(' - ');
         const workers = resData[1].split(', ');
         let restaurant = {};
         let isTheSameRest = false;

         if (restaurantsObjs.some(x => x.name == resData[0])) {
            restaurant = restaurantsObjs.find(x => x.name == resData[0]);
            isTheSameRest = true;
         } else {
            restaurant = {
               name: resData[0],
               workersObjects: [],
               sumSalaries: 0,
               maxSalary: 0
            }
         }

         for (let workerData of workers) {
            const worker = workerData.split(' ');

            const workerObj = {
               name: worker[0],
               salary: Number(worker[1])
            }

            restaurant.workersObjects.push(workerObj);
            restaurant.sumSalaries += Number(worker[1]);

            if (restaurant.maxSalary < Number(worker[1])) {
               restaurant.maxSalary = Number(worker[1]);
            }

         }

         if (!isTheSameRest) {
            restaurantsObjs.push(restaurant);
         }

         let avgSalary = restaurant.sumSalaries / restaurant.workersObjects.length;
         if (highestSalary < avgSalary) {
            highestSalary = avgSalary;
            bestSalary = restaurant.maxSalary;
            bestRest = restaurant.name;
            bestResWorkers = restaurant.workersObjects;
         }
      }

      let workersOutput = '';
      let sortedWorkers = bestResWorkers.sort((a, b) => b.salary - a.salary);

      for (let worker of sortedWorkers) {
         workersOutput += `Name: ${worker.name} With Salary: ${worker.salary} `;
      }

      document.querySelector('#bestRestaurant p').textContent = `Name: ${bestRest} Average Salary: ${highestSalary.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;
      document.querySelector('#workers p').textContent = workersOutput;
   }
}