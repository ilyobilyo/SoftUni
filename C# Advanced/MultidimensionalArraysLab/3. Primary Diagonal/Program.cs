using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int parameters = int.Parse(Console.ReadLine());

            int sum = 0;
            int[,] matrix = new int[parameters, parameters];
            for (int row = 0; row < parameters; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < parameters; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row, row];
            }


            Console.WriteLine(sum);
        }
    }
}
