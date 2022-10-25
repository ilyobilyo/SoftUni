using System;

namespace _3._Generating_01_Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var arr = new int[n];

            GenVector(arr, 0);
        }

        private static void GenVector(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(String.Join(String.Empty, arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;
                GenVector(arr, index + 1);
            }

        }
    }
}
