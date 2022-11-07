using System;
using System.Linq;

namespace _03._Bubble_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //O(n^2)
            BubbleSort(input);

            Console.WriteLine(String.Join(" ", input));
        }

        private static void BubbleSort(int[] array)
        {
            var sortNumbersCount = 0;

            while (sortNumbersCount < array.Length)
            {
                for (int i = 1; i <= array.Length - 1 - sortNumbersCount; i++)
                {
                    if (array[i - 1] > array[i])
                    {
                        Swap(array, i, i - 1);
                    }
                }

                sortNumbersCount++;
            }
        }

        private static void Swap(int[] array, int i, int min)
        {
            var temp = array[i];
            array[i] = array[min];
            array[min] = temp;
        }
    }
}
