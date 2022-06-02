using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsPassTheCrossroads = int.Parse(Console.ReadLine());
            Queue<string> carsQueue = new Queue<string>();
            int carsPassed = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                if (command == "green")
                {
                    if (carsQueue.Count >= carsPassTheCrossroads)
                    {
                        for (int i = 0; i < carsPassTheCrossroads; i++)
                        {
                            Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                            carsPassed++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < carsQueue.Count; i++)
                        {
                            Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                            carsPassed++;
                            i--;
                        }
                    }
                    
                }
                else
                {
                    carsQueue.Enqueue(command);
                }

            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
