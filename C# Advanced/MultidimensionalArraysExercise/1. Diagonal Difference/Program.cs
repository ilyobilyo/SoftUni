using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int primarySum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                primarySum += matrix[i, i];
            }

            int secondarySum = 0;
            int count = matrix.GetLength(0) - 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                secondarySum += matrix[i, count];
                count--;
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
