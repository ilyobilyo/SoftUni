using System;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            if (size <= 0)
            {
                return;
            }
            double[,] matrix = new double[size, size];
            for (int row = 0; row < size; row++)
            {
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            string[] bombsCoordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombsCoordinates.Length; i++)
            {
                string[] currBombCoordinates = bombsCoordinates[i].Split(",", StringSplitOptions.RemoveEmptyEntries);
                int bombRow = int.Parse(currBombCoordinates[0]);
                int bombCol = int.Parse(currBombCoordinates[1]);
                double bombValue = matrix[bombRow, bombCol];

                bool RowInRageDown = bombRow + 1 < matrix.GetLength(0);
                bool RowInRageUp = bombRow - 1 >= 0;
                bool ColInRageRight = bombCol + 1 < matrix.GetLength(1);
                bool ColInRageLeft = bombCol - 1 >= 0;

                if (bombValue > 0) // !! ne moje purvonachalnata stoinost na bombata da e 0 ili po malka !!
                {
                    matrix[bombRow, bombCol] = 0;

                    if (RowInRageUp)
                    {
                        if (matrix[bombRow - 1, bombCol] > 0)
                        {
                            matrix[bombRow - 1, bombCol] -= bombValue;
                        }

                        if (ColInRageLeft && matrix[bombRow - 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol - 1] -= bombValue;
                        }

                        if (ColInRageRight && matrix[bombRow - 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol + 1] -= bombValue;
                        }
                    }

                    if (RowInRageDown)
                    {
                        if (matrix[bombRow + 1, bombCol] > 0)
                        {
                            matrix[bombRow + 1, bombCol] -= bombValue;
                        }

                        if (ColInRageLeft && matrix[bombRow + 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol - 1] -= bombValue;
                        }

                        if (ColInRageRight && matrix[bombRow + 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol + 1] -= bombValue;
                        }
                    }

                    if (ColInRageLeft && matrix[bombRow, bombCol - 1] > 0)
                    {
                        matrix[bombRow, bombCol - 1] -= bombValue;
                    }

                    if (ColInRageRight && matrix[bombRow, bombCol + 1] > 0)
                    {
                        matrix[bombRow, bombCol + 1] -= bombValue;
                    }

                }

            }

            int aliveCells = 0;
            double sumAliveCells = 0;
            foreach (var number in matrix)
            {
                if (number > 0)
                {
                    aliveCells++;
                    sumAliveCells += number;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumAliveCells}");
            PrintMtrix(matrix);
        }

        static void PrintMtrix(double[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
