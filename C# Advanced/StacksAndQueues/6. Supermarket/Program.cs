using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> namesQueue = new Queue<string>();
            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    break;
                }

                if (name == "Paid" && namesQueue.Count > 0)
                {
                    while (namesQueue.Count != 0)
                    {
                        Console.WriteLine(namesQueue.Dequeue());
                    }

                }
                else
                {
                    namesQueue.Enqueue(name);
                }
            }

            Console.WriteLine($"{namesQueue.Count} people remaining.");
        }
    }
}
