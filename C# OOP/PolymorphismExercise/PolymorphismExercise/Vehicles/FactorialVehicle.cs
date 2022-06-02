using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles
{
    public static class FactorialVehicle
    {
        public static Vehicle GetVehicleType(string[] vehicleInfo)
        {
            Vehicle vehicle = null;

            string vehicleType = vehicleInfo[0];
            double vehicleQuantity = double.Parse(vehicleInfo[1]);
            double vehicleConsumption = double.Parse(vehicleInfo[2]);
            double vehicleTankCapacity = double.Parse(vehicleInfo[3]);

            if (vehicleType == "Car")
            {
                vehicle = new Car(vehicleQuantity, vehicleConsumption, vehicleTankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(vehicleQuantity, vehicleConsumption, vehicleTankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(vehicleQuantity, vehicleConsumption, vehicleTankCapacity);
            }

            return vehicle;
        }

        public static void DriveVehicle(string[] commandInfo)
        {
            string typeVehicle = commandInfo[1];
            double distanceOrLitersToRefuel = double.Parse(commandInfo[2]);

            if (typeVehicle == "Car")
            {
                car.Drive(distanceOrLitersToRefuel);
            }
            else if (typeVehicle == "Truck")
            {
                truck.Drive(distanceOrLitersToRefuel);
            }
            else if (typeVehicle == "Bus")
            {
                bus.IsEmpty = false;
                bus.Drive(distanceOrLitersToRefuel);
            }
        }
    }
}
