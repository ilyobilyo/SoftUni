using System;
using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();
            int numberOfCommands = int.Parse(Console.ReadLine());

            Vehicle car = FactorialVehicle.GetVehicleType(carInfo);
            Vehicle truck = FactorialVehicle.GetVehicleType(truckInfo);
            Vehicle bus = FactorialVehicle.GetVehicleType(busInfo);

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandInfo = Console.ReadLine().Split();

                string command = commandInfo[0];
                string typeVehicle = commandInfo[1];
                double distanceOrLitersToRefuel = double.Parse(commandInfo[2]);

                if (command == "Drive")
                {
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
                else if (command == "DriveEmpty")
                {
                    bus.IsEmpty = true;
                    bus.Drive(distanceOrLitersToRefuel);
                }
                else if (command == "Refuel")
                {
                    if (typeVehicle == "Car")
                    {
                        car.Refuel(distanceOrLitersToRefuel);
                    }
                    else if (typeVehicle == "Truck")
                    {
                        truck.Refuel(distanceOrLitersToRefuel);
                    }
                    else if (typeVehicle == "Bus")
                    {
                        bus.Refuel(distanceOrLitersToRefuel);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");

        }
    }
}
