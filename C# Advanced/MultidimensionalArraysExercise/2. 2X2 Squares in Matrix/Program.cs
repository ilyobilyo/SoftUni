using System;
using System.Linq;

namespace _2._2X2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = parameters[0];
            int colsCount = parameters[1];
            char[,] matrix = new char[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                char[] chars = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            int countEqualCells = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row,col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col] && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        countEqualCells++;
                    }
                }
            }

            Console.WriteLine(countEqualCells);
        }
    }
}
