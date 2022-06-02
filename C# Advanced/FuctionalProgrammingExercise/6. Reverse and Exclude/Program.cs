using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            Func<int[], int, List<int>> divisible = (arr, n) =>
            {
                List<int> result = new List<int>();

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % n != 0)
                    {
                        result.Add(arr[i]);
                    }
                }

                return result;
            };

            List<int> result = divisible(input, n);
            result.Reverse();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
