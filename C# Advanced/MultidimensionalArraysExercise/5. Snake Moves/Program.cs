using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCont = size[0];
            int colsCount = size[1];
            char[,] matrix = new char[rowsCont, colsCount];

            bool goingRight = true;
            string snake = Console.ReadLine();
            int count = 0;
            for (int row = 0; row < rowsCont; row++)
            {

                if (goingRight)
                {
                    for (int col = 0; col < colsCount; col++)
                    {
                        if (count == snake.Length)
                        {
                            count = 0;
                        }
                        matrix[row, col] = snake[count];
                        count++;
                    }

                    goingRight = false;
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (count == snake.Length)
                        {
                            count = 0;
                        }

                        matrix[row, col] = snake[count];
                        count++;
                    }

                    goingRight = true;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
