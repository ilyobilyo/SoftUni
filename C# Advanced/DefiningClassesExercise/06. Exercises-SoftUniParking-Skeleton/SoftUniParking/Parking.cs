using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            Cars = new Dictionary<string, Car>();
            Capacity = capacity;
        }

        public Dictionary<string, Car> Cars { get; set; }
        public int Capacity { get; set; }
        public int Count => Cars.Count;

        public string AddCar(Car car)
        {
            if (Cars.Count == Capacity)
            {
                return "Parking is full!";
            }
            else if (Cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else
            {
                Cars.Add(car.RegistrationNumber, car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }

        }

        public string RemoveCar(string registrationNumber)
        {
            if (Cars.ContainsKey(registrationNumber))
            {
                Cars.Remove(registrationNumber);
                return$"Successfully removed {registrationNumber}";
            }
            else
            {
                return"Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            if (Cars.ContainsKey(registrationNumber))
            {
                return Cars[registrationNumber];
            }
            else
            {
                return null;
            }
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var number in RegistrationNumbers)
            {
                if (Cars.ContainsKey(number))
                {
                    Cars.Remove(number);
                }
            }
        }
    }
}
