using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int parameters = int.Parse(Console.ReadLine());
            int[,] matrix = new int[parameters, parameters];
            for (int row = 0; row < parameters; row++)
            {
                int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < parameters; col++)
                {
                    matrix[row, col] = array[col];
                }

            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "END")
                {
                    break;
                }

                int rowCoordinate = int.Parse(command[1]);
                int colCoordinate = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if (rowCoordinate < 0 || rowCoordinate >= matrix.GetLength(0) || colCoordinate < 0 || colCoordinate >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command[0] == "Add")
                {
                    matrix[rowCoordinate, colCoordinate] += value;
                }
                else if (command[0] == "Subtract")
                {
                    matrix[rowCoordinate, colCoordinate] -= value;
                }
            }

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
