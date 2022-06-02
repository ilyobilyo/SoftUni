using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regularReservations = new HashSet<string>();
            HashSet<string> VIPReservations = new HashSet<string>();

            while (true)
            {
                string reseravtionNumber = Console.ReadLine();


                if (reseravtionNumber == "PARTY")
                {
                    break;
                }

                if (reseravtionNumber[0] >= 48 && reseravtionNumber[0] <= 57)
                {
                    VIPReservations.Add(reseravtionNumber);
                }
                else
                {
                    regularReservations.Add(reseravtionNumber);
                }
            }

            while (true)
            {
                string cameReservation = Console.ReadLine();
                if (cameReservation == "END")
                {
                    break;
                }

                if (regularReservations.Contains(cameReservation))
                {
                    regularReservations.Remove(cameReservation);
                }
                else if (VIPReservations.Contains(cameReservation))
                {
                    VIPReservations.Remove(cameReservation);
                }
            }




            Console.WriteLine(VIPReservations.Count + regularReservations.Count);

            foreach (var reservaton in VIPReservations)
            {
                Console.WriteLine(reservaton);
            }

            foreach (var reservation in regularReservations)
            {
                Console.WriteLine(reservation);
            }
        }
    }
}
