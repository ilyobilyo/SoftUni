using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            Tire[] currTires = new Tire[4];

            int countTires = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "No more tires")
                {
                    break;
                }

                string[] inputTires = input.Split();

                for (int i = 0; i < inputTires.Length - 1; i+=2)
                {
                    int tireYear = int.Parse(inputTires[i]);
                    double tirePressure = double.Parse(inputTires[i + 1]);

                    if (countTires < 4)
                    {
                        currTires[countTires] = new Tire(tireYear, tirePressure);
                        countTires++;
                    }

                    if (countTires == 4)
                    {
                        tires.Add(currTires);
                        currTires = new Tire[4];
                        countTires = 0;
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Engines done")
                {
                    break;
                }

                int horsePower = int.Parse(input.Split()[0]);
                double cubicCapacity = double.Parse(input.Split()[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Show special")
                {
                    break;
                }

                string[] carInfo = input.Split();

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]) / 100;
                int engineIndex = int.Parse(carInfo[5]);
                int tireIndex = int.Parse(carInfo[6]);

                Engine currCarEngine = engines[engineIndex];
                Tire[] currCarTires = tires[tireIndex];

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, currCarEngine, currCarTires));
            }

            List<Car> specialCars = new List<Car>();

            for (int i = 0; i < cars.Count; i++)
            {
                double currCarTiresPressureSum = 0;

                foreach (var tire in cars[i].Tyres)
                {
                    currCarTiresPressureSum += tire.Pressure;
                }


                if (cars[i].Year >= 2017 && cars[i].Engine.HorsePower > 330 && currCarTiresPressureSum >= 9 && currCarTiresPressureSum <= 10)
                {
                    cars[i].Drive(20);
                    if (cars[i].FuelQuantity > 0)
                    {
                        specialCars.Add(cars[i]);
                    }
                }
            }

            foreach (var car in specialCars)
            {
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }

        }
    }
}
