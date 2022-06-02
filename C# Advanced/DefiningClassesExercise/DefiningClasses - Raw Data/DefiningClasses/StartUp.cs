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

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int counter = 0; //Counter for Tires !!
                Tire[] tires = new Tire[4];
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                for (int j = 5; j < 12; j+=2)
                {
                    double tyrePressure = double.Parse(input[j]);
                    int tireAge = int.Parse(input[j + 1]);

                    tires[counter] = new Tire(tireAge, tyrePressure);
                    counter++;
                }

                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Engine engine = new Engine(engineSpeed, enginePower);
                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            List<Car> carsToPrint = new List<Car>();
            if (command == "fragile")
            {
                carsToPrint = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(x => x.Pressure < 1)).ToList();
            }
            else
            {
                carsToPrint = cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250).ToList();
            }

            foreach (var car in carsToPrint)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
