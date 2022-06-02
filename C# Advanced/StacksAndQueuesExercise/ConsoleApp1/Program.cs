using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elemetsToPush = input[0];
            int elemetsToPop = input[1];
            int searchedElement = input[2];

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stackNumbers = new Stack<int>();
            for (int i = 0; i < elemetsToPush; i++)
            {
                stackNumbers.Push(numbers[i]);
            }

            for (int i = 0; i < elemetsToPop; i++)
            {
                stackNumbers.Pop();
            }

            if (stackNumbers.Any())
            {
                if (stackNumbers.Any(x => x == searchedElement))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stackNumbers.Min());
                }

            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}
