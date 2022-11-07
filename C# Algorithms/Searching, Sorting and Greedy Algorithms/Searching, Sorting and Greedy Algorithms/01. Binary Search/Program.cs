using System;
using System.Linq;

namespace _01._Binary_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var element = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(input, element));
        }

        private static int BinarySearch(int[] array, int element)
        {
            var left = 0;
            var right = array.Length - 1;
            
            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (array[mid] == element)
                {
                    return mid;
                }

                if (element > array[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }

            }

            return -1;
        }
    }
}
