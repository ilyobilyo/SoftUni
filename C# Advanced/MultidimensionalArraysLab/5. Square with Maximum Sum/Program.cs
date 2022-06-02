using System;
using System.Linq;

namespace _5._Square_with_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rowsCount = parameters[0];
            int colsCount = parameters[1];
            int[,] matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int sum = 0;
            long maxSum = long.MinValue;
            int maxRow = 0;
            int maxCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            for (int row = maxRow; row < maxRow + 2; row++)
            {
                for (int col = maxCol; col < maxCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
