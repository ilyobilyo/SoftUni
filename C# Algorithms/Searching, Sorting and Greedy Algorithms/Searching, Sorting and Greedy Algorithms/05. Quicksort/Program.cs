using System;
using System.Linq;

namespace _05._Quicksort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            QuickSort(input, 0, input.Length - 1);

            Console.WriteLine(String.Join(" ", input));
        }

        private static void QuickSort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            var pivot = startIndex;
            var left = startIndex + 1;
            var right = endIndex;

            while (left <= right)
            {
                if (array[left] > array[pivot] && array[right] < array[pivot])
                {
                    Swap(array, left, right);
                }

                if (array[left] <= array[pivot])
                {
                    left++;
                }

                if (array[right] >= array[pivot])
                {
                    right--;
                }
            }

            Swap(array, pivot, right);

            var isLeftArrayIsSmaller = right - 1 - startIndex < endIndex - (right + 1);

            if (isLeftArrayIsSmaller)
            {
                QuickSort(array, startIndex, right - 1);
                QuickSort(array, right + 1, endIndex);
            }
            else
            {
                QuickSort(array, right + 1, endIndex);
                QuickSort(array, startIndex, right - 1);
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
