using System;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;
            int coalOnTheField = 0;
            int collectCoal = 0;

            for (int row = 0; row < size; row++)
            {
                char[] inputChars = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = inputChars[col];
                    if (inputChars[col] == 's')
                    {
                        playerCol = col;
                        playerRow = row;
                    }
                    else if (inputChars[col] == 'c')
                    {
                        coalOnTheField++;
                    }
                }
            }

            bool isEndCommands = true;

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "left")
                {
                    if (playerCol - 1 < 0)
                    {
                        continue;
                    }

                    playerCol--;
                }
                else if (commands[i] == "right")
                {
                    if (playerCol + 1 >= matrix.GetLength(1))
                    {
                        continue;
                    }

                    playerCol++;
                }
                else if (commands[i] == "up")
                {
                    if (playerRow - 1 < 0)
                    {
                        continue;
                    }

                    playerRow--;
                }
                else if (commands[i] == "down")
                {
                    if (playerRow + 1 >= matrix.GetLength(0))
                    {
                        continue;
                    }

                    playerRow++;
                }

                if (matrix[playerRow, playerCol] == 'c')
                {
                    collectCoal++;
                    matrix[playerRow, playerCol] = '*';
                }

                if (matrix[playerRow, playerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                    isEndCommands = false;
                    break;
                }

                if (collectCoal == coalOnTheField)
                {
                    Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                    isEndCommands = false;
                    break;
                }
            }

            if (isEndCommands)
            {
                Console.WriteLine($"{coalOnTheField - collectCoal} coals left. ({playerRow}, {playerCol})");
            }
        }
    }
}
