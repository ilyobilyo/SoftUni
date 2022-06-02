using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] arrays = new long[rows][];

            for (int i = 0; i < rows; i++)
            {
                arrays[i] = new long[i + 1];
                arrays[i][0] = 1;
                arrays[i][arrays[i].Length - 1] = 1;
                for (int j = 1; j < arrays[i].Length - 1; j++)
                {
                    arrays[i][j] = arrays[i - 1][j - 1] + arrays[i - 1][j];
                }
            }

            foreach (var array in arrays)
            {
                Console.WriteLine(string.Join(" ", array));
            }
        }
    }
}
