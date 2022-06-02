using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kidsNames = Console.ReadLine().Split();
            int removedPer = int.Parse(Console.ReadLine());
            Queue<string> hotPotato = new Queue<string>();
            int count = 1;

            for (int i = 0; i < kidsNames.Length; i++)
            {
                hotPotato.Enqueue(kidsNames[i]);
            }

            while (true)
            {
                if (hotPotato.Count == 1)
                {
                    break;
                }

                if (count == removedPer)
                {
                    Console.WriteLine("Removed " + hotPotato.Dequeue());
                    count = 1;
                }
                else
                {
                    string standKid = hotPotato.Dequeue();
                    hotPotato.Enqueue(standKid);
                    count++;
                }
            }

            Console.WriteLine($"Last is {hotPotato.Dequeue()}");
        }
    }
}
