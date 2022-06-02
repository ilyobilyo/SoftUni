using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._.Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = size[0];
            int colsCount = size[1];

            if (rowsCount < 3 || rowsCount > 20 || colsCount < 3 || colsCount > 20)
            {
                return;
            }

            char[,] matrix = new char[rowsCount, colsCount];
            Queue<int[]> bunniesCoordinates = new Queue<int[]>();
            int playerRow = 0;
            int playerCol = 0;
            bool isOnePlayer = false;

            for (int row = 0; row < rowsCount; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'B')
                    {
                        bunniesCoordinates.Enqueue(new int[] { row, col });
                    }

                    if (input[col] == 'P')
                    {
                        if (!isOnePlayer)
                        {
                            isOnePlayer = true;
                            playerRow = row;
                            playerCol = col;
                        }
                        else
                        {
                            matrix[row, col] = '.';
                        }
                    }
                }
            }

            bool isDead = false;
            bool isEscape = false;

            while (!isDead || !isEscape)
            {
                string commands = Console.ReadLine().ToUpper();
                for (int i = 0; i < commands.Length; i++)
                {
                    if (commands[i] == 'U')
                    {
                        bool isInRange = playerRow - 1 >= 0;
                        isEscape = playerRow - 1 < 0;

                        if (isInRange && matrix[playerRow - 1, playerCol] == '.')
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerRow--;
                            matrix[playerRow, playerCol] = 'P';
                        }
                        else if (isInRange && matrix[playerRow - 1, playerCol] == 'B')
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerRow--;
                            isDead = true;
                        }

                        if (isEscape)
                        {
                            matrix[playerRow, playerCol] = '.';
                        }
                    }
                    else if (commands[i] == 'D')
                    {
                        bool isInRange = playerRow + 1 < matrix.GetLength(0);
                        isEscape = playerRow + 1 >= matrix.GetLength(0);

                        if (isInRange && matrix[playerRow + 1, playerCol] == '.')
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerRow++;
                            matrix[playerRow, playerCol] = 'P';
                        }
                        else if (isInRange && matrix[playerRow + 1, playerCol] == 'B')
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerRow++;
                            isDead = true;
                        }

                        if (isEscape)
                        {
                            matrix[playerRow, playerCol] = '.';
                        }
                    }
                    else if (commands[i] == 'R')
                    {
                        bool isInRange = playerCol + 1 < matrix.GetLength(1);
                        isEscape = playerCol + 1 >= matrix.GetLength(1);


                        if (isInRange && matrix[playerRow, playerCol + 1] == '.')
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerCol++;
                            matrix[playerRow, playerCol] = 'P';
                        }
                        else if (isInRange && matrix[playerRow, playerCol + 1] == 'B')
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerCol++;
                            isDead = true;
                        }

                        if (isEscape)
                        {
                            matrix[playerRow, playerCol] = '.';
                        }
                    }
                    else if (commands[i] == 'L')
                    {
                        bool isInRange = playerCol - 1 >= 0;
                        isEscape = playerCol - 1 < 0;

                        if (isInRange && matrix[playerRow, playerCol - 1] == '.')
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerCol--;
                            matrix[playerRow, playerCol] = 'P';
                        }
                        else if (isInRange && matrix[playerRow, playerCol - 1] == 'B')
                        {
                            matrix[playerRow, playerCol] = '.';
                            playerCol--;
                            isDead = true;
                        }

                        if (isEscape)
                        {
                            matrix[playerRow, playerCol] = '.';
                        }
                    }

                    int bunniesCoordinatesCount = bunniesCoordinates.Count;
                    for (int j = 0; j < bunniesCoordinatesCount; j++)
                    {
                        int currBunnyRow = bunniesCoordinates.Peek()[0];
                        int currBunnyCol = bunniesCoordinates.Dequeue()[1];

                        if (currBunnyRow + 1 < matrix.GetLength(0))
                        {
                            if (matrix[currBunnyRow + 1, currBunnyCol] == 'P')
                            {
                                matrix[currBunnyRow + 1, currBunnyCol] = 'B';
                                isDead = true;
                            }
                            else if (matrix[currBunnyRow + 1, currBunnyCol] == '.')
                            {
                                matrix[currBunnyRow + 1, currBunnyCol] = 'B';
                                bunniesCoordinates.Enqueue(new int[] { currBunnyRow + 1, currBunnyCol });
                            }
                        }

                        if (currBunnyRow - 1 >= 0)
                        {
                            if (matrix[currBunnyRow - 1, currBunnyCol] == 'P')
                            {
                                matrix[currBunnyRow - 1, currBunnyCol] = 'B';
                                isDead = true;
                            }
                            else if (matrix[currBunnyRow - 1, currBunnyCol] == '.')
                            {
                                matrix[currBunnyRow - 1, currBunnyCol] = 'B';
                                bunniesCoordinates.Enqueue(new int[] { currBunnyRow - 1, currBunnyCol });
                            }
                        }

                        if (currBunnyCol + 1 < matrix.GetLength(1))
                        {
                            if (matrix[currBunnyRow, currBunnyCol + 1] == 'P')
                            {
                                matrix[currBunnyRow, currBunnyCol + 1] = 'B';
                                isDead = true;
                            }
                            else if (matrix[currBunnyRow, currBunnyCol + 1] == '.')
                            {
                                matrix[currBunnyRow, currBunnyCol + 1] = 'B';
                                bunniesCoordinates.Enqueue(new int[] { currBunnyRow, currBunnyCol + 1 });
                            }
                        }

                        if (currBunnyCol - 1 >= 0)
                        {
                            if (matrix[currBunnyRow, currBunnyCol - 1] == 'P')
                            {
                                matrix[currBunnyRow, currBunnyCol - 1] = 'B';
                                isDead = true;
                            }
                            else if (matrix[currBunnyRow, currBunnyCol - 1] == '.')
                            {
                                matrix[currBunnyRow, currBunnyCol - 1] = 'B';
                                bunniesCoordinates.Enqueue(new int[] { currBunnyRow, currBunnyCol - 1 });
                            }
                        }

                    }
                    

                    if (isEscape)
                    {
                        Print(matrix);
                        Console.WriteLine($"won: {playerRow} {playerCol}");
                        Environment.Exit(0);
                    }

                    if (isDead)
                    {
                        Print(matrix);
                        Console.WriteLine($"dead: {playerRow} {playerCol}");
                        Environment.Exit(0);
                    }

                }
            }
        }

        static void Print(char[,] matrix)
        {
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
