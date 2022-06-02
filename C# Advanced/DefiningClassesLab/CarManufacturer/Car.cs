using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Car
    {
        string make;
        string model;
        int year;
        double fuelQantity;
        double fuelConsumption;
        Engine engine;
        Tire[] tyres;

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model,year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tyres) : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tyres = tyres;
        }

        public string Make { get { return this.make; } set { this.make = value; } }
        public string Model { get { return this.model; } set { this.model = value; } }
        public int Year { get { return this.year; } set { this.year = value; } }
        public double FuelQuantity { get { return this.fuelQantity; } set { this.fuelQantity = value; } }
        public double FuelConsumption { get { return this.fuelConsumption; } set { this.fuelConsumption = value; } }
        public Engine Engine { get; set; }
        public Tire[] Tyres { get; set; }


        public void Drive(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumption) > 0)
            {
                FuelQuantity -= distance * FuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make: {Make} Model: {Model} Year: {Year} Fuel: {FuelQuantity:f2}";
        }
    }
}
