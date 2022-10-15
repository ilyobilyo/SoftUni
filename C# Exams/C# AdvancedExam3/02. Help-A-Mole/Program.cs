using System;
using System.Collections.Generic;

namespace _02._Help_A_Mole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];

            var moleRow = -1;
            var moleCol = -1;

            var points = 0;

            var specials = new List<Special>();

            for (int row = 0; row < n; row++)
            {
                var inputRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputRow[col];

                    if (inputRow[col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }
                    else if (inputRow[col] == 'S')
                    {
                        specials.Add(new Special(row, col));
                    }
                }
            }

            while (points < 25)
            {
                var command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                var oldRow = moleRow;
                var oldCol = moleCol;

                switch (command)
                {
                    case "up":
                        {
                            moleRow--;
                            break;
                        }
                    case "down":
                        {
                            moleRow++;
                            break;
                        }
                    case "left":
                        {
                            moleCol--;
                            break;
                        }
                    case "right":
                        {
                            moleCol++;
                            break;
                        }
                }

                if (moleRow >= 0 && moleRow < matrix.GetLength(0) && moleCol >= 0 && moleCol < matrix.GetLength(1))
                {
                    matrix[oldRow, oldCol] = '-';

                    if (matrix[moleRow, moleCol] == 'S')
                    {
                        if (specials[0].Row == moleRow && specials[0].Col == moleCol)
                        {
                            matrix[moleRow, moleCol] = '-';

                            moleRow = specials[1].Row;
                            moleCol = specials[1].Col;

                            matrix[moleRow, moleCol] = 'M';
                        }
                        else
                        {
                            matrix[moleRow, moleCol] = '-';

                            moleRow = specials[0].Row;
                            moleCol = specials[0].Col;

                            matrix[moleRow, moleCol] = 'M';
                        }

                        points -= 3;
                    }
                    else if (matrix[moleRow, moleCol] >= 48 && matrix[moleRow, moleCol] <= 57)
                    {
                        points += int.Parse(matrix[moleRow, moleCol].ToString());

                        matrix[moleRow, moleCol] = 'M';
                    }
                    else
                    {
                        matrix[moleRow, moleCol] = 'M';
                    }
                }
                else
                {
                    Console.WriteLine("Don't try to escape the playing field!");

                    moleRow = oldRow;
                    moleCol = oldCol;
                }
            }

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");

                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");

                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
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

    class Special
    {
        public Special(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}
