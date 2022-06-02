using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelCosumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelCosumption;
            TravelledDistance = 0;
        }


        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(int amaountOfKm)
        {
            if (FuelAmount - (amaountOfKm * FuelConsumptionPerKilometer) >= 0)
            {
                FuelAmount -= amaountOfKm * FuelConsumptionPerKilometer;
                TravelledDistance += amaountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TravelledDistance}";
        }
    }
}
