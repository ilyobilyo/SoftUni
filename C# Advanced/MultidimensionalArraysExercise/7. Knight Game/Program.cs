using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }


            int removedKnight = 0;
            while (true)
            {
                int maxAttaks = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int currAttaks = 0;
                        if (matrix[row, col] == '0')
                        {
                            continue;
                        }

                        // (!)(1) Proverqvam za vsqka otdelna poziciq na koqto moje da otide konq (Za celta izpolzvam samo if-ove)
                        if (row - 2 >= 0 && col + 1 < matrix.GetLength(1) && matrix[row - 2, col + 1] == 'K')
                        {
                            currAttaks++;
                        }

                        // (!)(1)
                        if (row - 1 >= 0 && col + 2 < matrix.GetLength(1) && matrix[row - 1, col + 2] == 'K')
                        {
                            currAttaks++;

                        }

                        // (!)(1)
                        if (row + 1 < matrix.GetLength(0) && col + 2 < matrix.GetLength(1) && matrix[row + 1, col + 2] == 'K')
                        {
                            currAttaks++;

                        }

                        // (!)(1)
                        if (row + 2 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1) && matrix[row + 2, col + 1] == 'K')
                        {
                            currAttaks++;
                        }

                        // (!)(1)
                        if (row + 2 < matrix.GetLength(0) && col - 1 >= 0 && matrix[row + 2, col - 1] == 'K')
                        {
                            currAttaks++;
                        }

                        // (!)(1)
                        if (row + 1 < matrix.GetLength(0) && col - 2 >= 0 && matrix[row + 1, col - 2] == 'K')
                        {
                            currAttaks++;
                        }

                        // (!)(1)
                        if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1, col - 2] == 'K')
                        {
                            currAttaks++;
                        }

                        // (!)(1)
                        if (row - 2 >= 0 && col - 1 >= 0 && matrix[row - 2, col - 1] == 'K')
                        {
                            currAttaks++;
                        }

                        if (currAttaks > maxAttaks)
                        {
                            maxAttaks = currAttaks;
                            knightRow = row;
                            knightCol = col;
                        }

                    }
                }

                if (maxAttaks == 0)
                {
                    Console.WriteLine(removedKnight);
                    break;
                }
                else
                {
                    matrix[knightRow, knightCol] = '0';
                    removedKnight++;
                }

            }


        }
    }
}
