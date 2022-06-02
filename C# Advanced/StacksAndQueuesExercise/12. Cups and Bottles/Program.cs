using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottels = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> bottlesStack = new Stack<int>(bottels);
            Queue<int> cupsQueue = new Queue<int>(cups);

            int wasteWater = 0;

            while (bottlesStack.Any() && cupsQueue.Any())
            {
                int currentBottle = bottlesStack.Pop();
                int currentCup = cupsQueue.Dequeue();

                if (currentBottle - currentCup >= 0)
                {
                    currentBottle -= currentCup;
                    wasteWater += currentBottle;
                }
                else
                {
                    while (true)
                    {
                        if (currentCup - currentBottle <= 0)
                        {
                            currentBottle -= currentCup;
                            wasteWater += currentBottle;
                            break;
                        }
                        else
                        {
                            currentCup -= currentBottle;
                            currentBottle = bottlesStack.Pop();
                        }
                    }
                }
            }

            if (bottlesStack.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottlesStack)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsQueue)}");
            }

            Console.WriteLine($"Wasted litters of water: {wasteWater}");
        }
    }
}
