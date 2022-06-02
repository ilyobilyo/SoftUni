using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> clothesInBox = new Stack<int>(clothes);
            int clothesSum = 0;
            int usedRacks = 1;

            while (clothesInBox.Count > 0)
            {
                clothesSum += clothesInBox.Peek();

                //Po burzo e taka
                if (clothesSum <= rackCapacity)
                {
                    clothesInBox.Pop();
                }
                else
                {
                    usedRacks++;
                    clothesSum = 0;
                }

            }

            Console.WriteLine(usedRacks);
        }
    }
}
