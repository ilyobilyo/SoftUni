using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = matrixSize[0];
            int colsCount = matrixSize[1];
            int[,] matrix = new int[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int currSum = 0;
            int maxSum = int.MinValue;
            int maxRow = -1;
            int maxCol = -1;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    currSum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                           matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                           matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        maxRow = row;
                        maxCol = col;
                    }

                    currSum = 0;
                }

            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = maxRow; row <= maxRow + 2; row++)
            {
                for (int col = maxCol; col <= maxCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
