using System;
using System.Collections.Generic;

namespace _02._Wall_Destroyer
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];

            var vankoRow = -1;
            var vankoCol = -1;

            var holesCount = 0;
            var rodsCount = 0;

            var isElectrocuted = false;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "End")
                {
                    holesCount++;
                    break;
                }

                var oldVankoRow = vankoRow;
                var oldVankoCol = vankoCol;

                switch (command)
                {
                    case "up":
                        {
                            vankoRow--;
                            break;
                        }
                    case "down":
                        {
                            vankoRow++;
                            break;
                        }
                    case "left":
                        {
                            vankoCol--;
                            break;
                        }
                    case "right":
                        {
                            vankoCol++;
                            break;
                        }
                }

                if (vankoRow >= 0 && vankoRow < matrix.GetLength(0) && vankoCol >= 0 && vankoCol < matrix.GetLength(1))
                {

                    if (matrix[vankoRow, vankoCol] == 'R')
                    {
                        vankoRow = oldVankoRow;
                        vankoCol = oldVankoCol;

                        rodsCount++;

                        Console.WriteLine("Vanko hit a rod!");
                        continue;
                    }
                    else if (matrix[vankoRow, vankoCol] == 'C')
                    {
                        matrix[oldVankoRow, oldVankoCol] = '*';
                        holesCount++;
                        matrix[vankoRow, vankoCol] = 'E';
                        isElectrocuted = true;
                        holesCount++;
                        break;
                    }
                    else if (matrix[vankoRow, vankoCol] == '*')
                    {
                        matrix[oldVankoRow, oldVankoCol] = '*';
                        matrix[vankoRow, vankoCol] = 'V';

                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                    else
                    {
                        matrix[oldVankoRow, oldVankoCol] = '*';
                        matrix[vankoRow, vankoCol] = 'V';
                        holesCount++;
                    }
                }
                else
                {
                    vankoRow = oldVankoRow;
                    vankoCol = oldVankoCol;
                }
            }

            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {rodsCount} rod(s).");
            }

            Print(matrix);
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
