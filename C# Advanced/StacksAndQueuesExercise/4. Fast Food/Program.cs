using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] orderQuantity = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(orderQuantity);
            int biggestOrder = orders.Max();
            while (orders.Any())
            {
                int currOrder = orders.Peek();

                if (quantity - currOrder >= 0)
                {
                    quantity -= currOrder;
                    orders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(biggestOrder);

            if (orders.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
