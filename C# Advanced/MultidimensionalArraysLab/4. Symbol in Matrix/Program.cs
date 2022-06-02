using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int parameters = int.Parse(Console.ReadLine());

            char[,] matrix = new char[parameters, parameters];
            for (int row = 0; row < parameters; row++)
            {
                string symbols = Console.ReadLine();
                for (int col = 0; col < parameters; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            char searchedChar = char.Parse(Console.ReadLine());
            int searchedCharRow = 0;
            int searchedCharCol = 0;
            bool isFind = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == searchedChar)
                    {
                        searchedCharRow = row;
                        searchedCharCol = col;
                        isFind = true;
                        break;
                    }
                }

                if (isFind)
                {
                    break;
                }
            }

            if (isFind)
            {
                Console.WriteLine($"({searchedCharRow}, {searchedCharCol})");
            }
            else
            {
                Console.WriteLine($"{searchedChar} does not occur in the matrix");
            }
        }
    }
}
