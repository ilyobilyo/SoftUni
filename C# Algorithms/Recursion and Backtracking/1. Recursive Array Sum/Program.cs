using System;
using System.Linq;

namespace _1._Recursive_Array_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(SumRecursivly(arr, 0));
        }

        private static int SumRecursivly(int[] arr, int index)
        {
            if (index >= arr.Length - 1)
            {
                return arr[index];
            }

            var sum = arr[index] + SumRecursivly(arr, index + 1);

            return sum;
        }
    }
}
