using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[numberOfRows][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                double[] inputNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jaggedArray[row] = inputNumbers;
            }

            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "End")
                {
                    break;
                }

                int currRow = int.Parse(command[1]);
                int currCol = int.Parse(command[2]);
                double value = int.Parse(command[3]);
                if (command[0] == "Add")
                {
                    if (currRow >= 0 && currRow < jaggedArray.Length && currCol >= 0 && currCol < jaggedArray[currRow].Length)
                    {
                        jaggedArray[currRow][currCol] += value;
                    }
                }
                else
                {
                    if (currRow >= 0 && currRow < jaggedArray.Length && currCol >= 0 && currCol < jaggedArray[currRow].Length)
                    {
                        jaggedArray[currRow][currCol] -= value;
                    }
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }
        }

       
    }
}
