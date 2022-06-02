using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        protected double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            TankCapacity = tankCapacity;
            FuelConsumption = fuelConsumption;
            IsEmpty = false;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        

        public double TankCapacity { get; set; }

        public bool IsEmpty { get; set; }
        public abstract void Drive(double distance);

        public abstract void Refuel(double amountOfFuel);
    }
}
