using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                if (!cars.ContainsKey(model))
                {
                    cars.Add(model, new Car(model, fuelAmount, fuelConsumption));
                }


            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "End")
                {
                    break;
                }

                string drivenCarModel = command[1];
                int amountOfKm = int.Parse(command[2]);

                if (cars.ContainsKey(drivenCarModel))
                {
                    Car drivenCar = cars.FirstOrDefault(x => x.Key == drivenCarModel).Value;
                    drivenCar.Drive(amountOfKm);
                }

            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Value);
            }
        }
    }
}
