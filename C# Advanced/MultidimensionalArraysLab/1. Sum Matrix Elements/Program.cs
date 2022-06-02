using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parameters = Console.ReadLine().Split(", ");
            int rowsCount = int.Parse(parameters[0]);
            int colsCount = int.Parse(parameters[1]);

            int sum = 0;
            int[,] matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = numbers[col];
                    sum += numbers[col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
            
        }
    }
}
