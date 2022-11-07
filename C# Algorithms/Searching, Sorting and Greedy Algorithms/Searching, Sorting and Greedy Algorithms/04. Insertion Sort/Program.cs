using System;
using System.Linq;

namespace _04._Insertion_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //O(n^2)
            InsertionSort(input);

            Console.WriteLine(String.Join(" ", input));
        }

        private static void InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var j = i;

                while (j > 0 && array[j] < array[j - 1])
                {
                    Swap(array, j, j - 1);
                    j--;
                }
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
