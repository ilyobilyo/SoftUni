using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += 0.9;
        }

        public override void Drive(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumption) >= 0)
            {
                FuelQuantity -= distance * FuelConsumption;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
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
                FuelQuantity += amountOfFuel;
            }
        }
    }
}
