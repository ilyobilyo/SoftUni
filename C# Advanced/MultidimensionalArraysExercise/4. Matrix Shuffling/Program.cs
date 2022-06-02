using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = size[0];
            int colsCount = size[1];
            string[,] matrix = new string[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "END")
                {
                    break;
                }

                if (command[0] == "swap")
                {
                    if (IsUnvalid(matrix, command))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    else
                    {
                        int rowFirstCoordinate = int.Parse(command[1]);
                        int colFirstCoordinate = int.Parse(command[2]);
                        int rowSecondCoordinate = int.Parse(command[3]);
                        int colSecondCoordinate = int.Parse(command[4]);

                        string firstValue = matrix[rowFirstCoordinate, colFirstCoordinate];
                        string secondValue = matrix[rowSecondCoordinate, colSecondCoordinate];

                        matrix[rowFirstCoordinate, colFirstCoordinate] = secondValue;
                        matrix[rowSecondCoordinate, colSecondCoordinate] = firstValue;

                        PrintMatrix(matrix);
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
            }
        }

        static bool IsUnvalid(string[,] matrix, string[] command)
        {
            if (command.Length == 5)
            {
                int rowFirstCoordinate = int.Parse(command[1]);
                int colFirstCoordinate = int.Parse(command[2]);
                int rowSecondCoordinate = int.Parse(command[3]);
                int colSecondCoordinate = int.Parse(command[4]);

                if (rowFirstCoordinate == rowSecondCoordinate && colFirstCoordinate == colSecondCoordinate)
                {
                    return true;
                }
                else
                {
                    return rowFirstCoordinate < 0 || rowFirstCoordinate >= matrix.GetLength(0) || colFirstCoordinate < 0 || colFirstCoordinate >= matrix.GetLength(1)
                        || rowSecondCoordinate < 0 || rowSecondCoordinate >= matrix.GetLength(0) || colSecondCoordinate < 0 || colSecondCoordinate >= matrix.GetLength(1);
                }
            }
            else
            {
                return true;
            }

        }

        static void PrintMatrix(string[,] matrix)
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
