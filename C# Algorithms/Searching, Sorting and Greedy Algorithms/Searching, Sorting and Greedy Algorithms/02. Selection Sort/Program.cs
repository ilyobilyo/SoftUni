using System;
using System.Linq;

namespace _02._Selection_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //O(n^2)
            SelectionSort(input);

            Console.WriteLine(String.Join(" ", input));
        }

        private static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                Swap(array, i, min);
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
