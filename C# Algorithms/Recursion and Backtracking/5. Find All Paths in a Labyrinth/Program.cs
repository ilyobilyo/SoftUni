using System;
using System.Collections.Generic;

namespace _5._Find_All_Paths_in_a_Labyrinth
{
    internal class Program
    {
        public static List<string> paths = new List<string>();

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new char[rows, cols];

            var startRow = 0;
            var startCol = 0;

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            FindAllPaths(matrix, startRow, startCol);
        }

        private static void FindAllPaths(char[,] matrix, int row, int col, string direction = null)
        {
            if (IsInvalid(matrix, row, col))
            {
                return;
            }


            if (matrix[row, col] == '*' || matrix[row, col] == 'v')
            {
                return;
            }

            if (direction != null)
            {
                paths.Add(direction);
            }

            if (matrix[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, paths));
                paths.RemoveAt(paths.Count - 1);
                return;
            }

            matrix[row,col] = 'v';

            FindAllPaths(matrix, row - 1, col, "U");
            FindAllPaths(matrix, row + 1, col, "D");
            FindAllPaths(matrix, row, col - 1, "L");
            FindAllPaths(matrix, row, col + 1, "R");

            matrix[row, col] = '-';

            if (paths.Count > 0)
            {
                paths.RemoveAt(paths.Count - 1);
            }
        }

        private static bool IsInvalid(char[,] matrix, int row, int col)
            => row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1);
    }
}
