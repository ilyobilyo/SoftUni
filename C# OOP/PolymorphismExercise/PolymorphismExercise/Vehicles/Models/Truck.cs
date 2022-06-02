using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption += 1.6;
        }

        public override void Drive(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumption) >= 0)
            {
                FuelQuantity -= distance * FuelConsumption;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double amountOfFuel)
        {
            if (amountOfFuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            if (FuelQuantity + amountOfFuel > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amountOfFuel} fuel in the tank");
            }
            else
            {
                FuelQuantity += amountOfFuel * 0.95;
            }
        }
    }
}
