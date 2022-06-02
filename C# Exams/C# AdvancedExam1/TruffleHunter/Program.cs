using System;

namespace TruffleHunter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split();
                for (int cow = 0; cow < matrix.GetLength(1); cow++)
                {
                    matrix[row, cow] = input[cow];
                }
            }

            int whiteTrufflesCount = 0;
            int blackTrufflesCount = 0;
            int summerTrufflesCount = 0;
            int boarTrufflesCount = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop the hunt")
                {
                    break;
                }

                string[] command = input.Split();
                if (command[0] == "Collect")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);

                    if (matrix[row, col] == "W")
                    {
                        whiteTrufflesCount++;
                        matrix[row, col] = "-";
                    }
                    else if (matrix[row, col] == "S")
                    {
                        summerTrufflesCount++;
                        matrix[row, col] = "-";
                    }
                    else if (matrix[row, col] == "B")
                    {
                        blackTrufflesCount++;
                        matrix[row, col] = "-";
                    }
                }
                else if (command[0] == "Wild_Boar")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    string direction = command[3];

                    if (matrix[row, col] != "-")
                    {
                        boarTrufflesCount++;
                        matrix[row, col] = "-";

                    }

                    if (direction == "up")
                    {
                        for (int i = row; i >= 0; i -= 2)
                        {
                            if (matrix[i, col] != "-")
                            {
                                boarTrufflesCount++;
                                matrix[i, col] = "-";
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < matrix.GetLength(0); i += 2)
                        {
                            if (matrix[i, col] != "-")
                            {
                                boarTrufflesCount++;
                                matrix[i, col] = "-";
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= 0; i-=2)
                        {
                            if (matrix[row, i] != "-")
                            {
                                boarTrufflesCount++;
                                matrix[row, i] = "-";
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i < matrix.GetLength(1); i+=2)
                        {
                            if (matrix[row, i] != "-")
                            {
                                boarTrufflesCount++;
                                matrix[row, i] = "-";
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTrufflesCount} black, {summerTrufflesCount} summer, and {whiteTrufflesCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTrufflesCount} truffles.");
            PrintMatrix(matrix);
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
