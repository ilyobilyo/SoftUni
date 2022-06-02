using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            if (!IsEmpty)
            {
                if (FuelQuantity - (distance * (FuelConsumption + 1.4)) >= 0)
                {
                    FuelQuantity -= distance * (FuelConsumption + 1.4);
                    Console.WriteLine($"Bus travelled {distance} km");
                }
                else
                {
                    Console.WriteLine("Bus needs refueling");
                }

            }
            else
            {
                if (FuelQuantity - (distance * FuelConsumption) >= 0)
                {
                    FuelQuantity -= distance * FuelConsumption;
                    Console.WriteLine($"Bus travelled {distance} km");
                }
                else
                {
                    Console.WriteLine("Bus needs refueling");
                }
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
