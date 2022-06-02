using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elemetsToEnqueue = input[0];
            int elemetsToDequeue = input[1];
            int searchedElement = input[2];

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < elemetsToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < elemetsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Any())
            {
                if (queue.Any(x => x == searchedElement))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}
