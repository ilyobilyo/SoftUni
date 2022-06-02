using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolBumps = int.Parse(Console.ReadLine());

            Queue<int[]> queueBumps = new Queue<int[]>();
            for (int i = 0; i < petrolBumps; i++)
            {
                int[] bumpInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queueBumps.Enqueue(bumpInfo);
            }

            int startIndex = 0;
            while (true)
            {
                //zanulqvam vinagi kato e neuspeshna obikolkata
                int petrolSum = 0;
                //minavam prez vs benzinostancii ako mi stigne gorivoto
                foreach (var item in queueBumps)
                {
                    int petrol = item[0];
                    int distance = item[1];

                    //dobavqm benz v kolata
                    petrolSum += petrol;
                    //vadq distanciqta zashtoto mi harchi 1 litur za 1 kilometur
                    petrolSum -= distance;

                    if (petrolSum < 0)
                    {
                        int[] currBump = queueBumps.Dequeue();
                        queueBumps.Enqueue(currBump);
                        //minavam kum sledvashtata benzinostanciq
                        startIndex++;
                        break;
                    }

                }

                if (petrolSum >= 0)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }

        }
    }
}
