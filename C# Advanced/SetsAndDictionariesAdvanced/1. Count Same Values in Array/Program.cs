using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Dictionary<double, int> dict = new Dictionary<double, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!dict.ContainsKey(input[i]))
                {
                    dict.Add(input[i], 1);
                }
                else
                {
                    dict[input[i]]++;
                }
            }

            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
