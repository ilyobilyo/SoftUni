using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingData = new HashSet<string>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "END")
                {
                    break;
                }

                string direction = input[0];
                string carNumber = input[1];

                if (direction == "IN")
                {
                    parkingData.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    parkingData.Remove(carNumber);
                }
            }

            if (parkingData.Count > 0)
            {
                foreach (var cars in parkingData)
                {
                    Console.WriteLine(cars);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
