﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverAtWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int beaverRow = -1;
            int beaverCol = -1;
            int countOfBranches = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (input[col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }

                    if (char.IsLower(input[col]))
                    {
                        countOfBranches++;
                    }

                    matrix[row, col] = input[col];
                }
            }

            Stack<char> collectedBranches = new Stack<char>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end" || countOfBranches <= 0)
                {
                    break;
                }

                if (command == "up")
                {
                    if (IsInRange(matrix, beaverRow - 1, beaverCol))
                    {
                        if (char.IsLower(matrix[beaverRow - 1, beaverCol]))
                        {
                            collectedBranches.Push(matrix[beaverRow - 1, beaverCol]);
                            matrix[beaverRow - 1, beaverCol] = 'B';
                            beaverRow--;
                            countOfBranches--;
                        }
                        else if (char.IsUpper(matrix[beaverRow - 1, beaverCol]))
                        {
                            matrix[beaverRow - 1, beaverCol] = '-';
                            if (beaverRow - 1 == 0)
                            {
                                matrix[beaverRow, beaverCol] = '-';
                                matrix[matrix.GetLength(0) - 1, beaverCol] = 'B';
                                beaverRow = matrix.GetLength(0) - 1;
                            }
                            else
                            {
                                matrix[beaverRow, beaverCol] = '-';
                                matrix[0, beaverCol] = 'B';
                                beaverRow = 0;
                            }
                        }
                        else
                        {
                            matrix[beaverRow - 1, beaverCol] = 'B';
                            matrix[beaverRow, beaverCol] = '-';
                            beaverRow--;
                        }
                        
                    }
                    else
                    {
                        collectedBranches.Pop();
                    }
                }
                else if (command == "down")
                {
                    if (IsInRange(matrix, beaverRow + 1, beaverCol))
                    {
                        if (char.IsLower(matrix[beaverRow + 1, beaverCol]))
                        {
                            collectedBranches.Push(matrix[beaverRow + 1, beaverCol]);
                            matrix[beaverRow + 1, beaverCol] = 'B';
                            beaverRow++;
                            countOfBranches--;
                        }
                        else if (char.IsUpper(matrix[beaverRow + 1, beaverCol]))
                        {
                            matrix[beaverRow + 1, beaverCol] = '-';
                            if (beaverRow + 1 == matrix.GetLength(0) - 1)
                            {
                                matrix[beaverRow, beaverCol] = '-';
                                matrix[0, beaverCol] = 'B';
                                beaverRow = 0;
                            }
                            else
                            {
                                matrix[beaverRow, beaverCol] = '-';
                                matrix[matrix.GetLength(0) - 1, beaverCol] = 'B';
                                beaverRow = matrix.GetLength(0) - 1;
                            }
                        }
                        else
                        {
                            matrix[beaverRow + 1, beaverCol] = 'B';
                            matrix[beaverRow, beaverCol] = '-';
                            beaverRow++;
                        }

                    }
                    else
                    {
                        collectedBranches.Pop();
                    }
                }
                else if (command == "left")
                {
                    if (IsInRange(matrix, beaverRow, beaverCol - 1))
                    {
                        if (char.IsLower(matrix[beaverRow, beaverCol - 1]))
                        {
                            collectedBranches.Push(matrix[beaverRow, beaverCol - 1]);
                            matrix[beaverRow, beaverCol - 1] = 'B';
                            beaverCol--;
                            countOfBranches--;
                        }
                        else if (char.IsUpper(matrix[beaverRow, beaverCol - 1]))
                        {
                            matrix[beaverRow, beaverCol - 1] = '-';
                            if (beaverCol - 1 == 0)
                            {
                                matrix[beaverRow, beaverCol] = '-';
                                matrix[beaverRow, matrix.GetLength(1) - 1] = 'B';
                                beaverCol = matrix.GetLength(1) - 1;
                            }
                            else
                            {
                                matrix[beaverRow, beaverCol] = '-';
                                matrix[beaverRow, 0] = 'B';
                                beaverCol = 0;
                            }
                        }
                        else
                        {
                            matrix[beaverRow, beaverCol - 1] = 'B';
                            matrix[beaverRow, beaverCol] = '-';
                            beaverCol--;
                        }

                    }
                    else
                    {
                        collectedBranches.Pop();
                    }
                }
                else if (command == "right")
                {
                    if (IsInRange(matrix, beaverRow, beaverCol + 1))
                    {
                        if (char.IsLower(matrix[beaverRow, beaverCol + 1]))
                        {
                            collectedBranches.Push(matrix[beaverRow, beaverCol + 1]);
                            matrix[beaverRow, beaverCol + 1] = 'B';
                            beaverCol++;
                            countOfBranches--;
                        }
                        else if (char.IsUpper(matrix[beaverRow, beaverCol + 1]))
                        {
                            matrix[beaverRow, beaverCol + 1] = '-';
                            if (beaverCol + 1 == matrix.GetLength(1) - 1)
                            {
                                matrix[beaverRow, beaverCol] = '-';
                                matrix[beaverRow, 0] = 'B';
                                beaverCol = 0;
                            }
                            else
                            {
                                matrix[beaverRow, beaverCol] = '-';
                                matrix[beaverRow, matrix.GetLength(1) - 1] = 'B';
                                beaverCol = matrix.GetLength(1) - 1;
                            }
                        }
                        else
                        {
                            matrix[beaverRow, beaverCol + 1] = 'B';
                            matrix[beaverRow, beaverCol] = '-';
                            beaverCol++;
                        }

                    }
                    else
                    {
                        collectedBranches.Pop();
                    }
                }
            }

            if (countOfBranches > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countOfBranches} branches left.");
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {collectedBranches.Count} wood branches: {string.Join(", ", collectedBranches)}");
            }

            PrintMatrix(matrix);
        }

        static bool IsInRange(char[,] matrix, int row, int col)
        {
            return row > 0 && row < matrix.GetLength(0) && col > 0 && col < matrix.GetLength(1);
        }

        static void PrintMatrix(char[,] matrix)
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
