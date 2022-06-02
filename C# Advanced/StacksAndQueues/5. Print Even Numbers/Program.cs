using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            foreach (var item in numbers)
            {
                queue.Enqueue(item);
            }

            for (int i = 0; i < queue.Count; i++)
            {
                if (queue.Peek() % 2 != 0)
                {
                    queue.Dequeue();
                    i--; // Vadq indexa zashtoto vadq element i ne iskam indexa da produljava napred v opashkata !!
                }
                else
                {
                    var evenNumber = queue.Dequeue();
                    queue.Enqueue(evenNumber);
                }
            }

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
