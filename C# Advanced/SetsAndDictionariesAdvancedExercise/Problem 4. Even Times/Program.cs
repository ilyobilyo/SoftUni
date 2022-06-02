using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(number))
                {
                    dict.Add(number, 1);
                }
                else
                {
                    dict[number]++;
                }
            }

            int numberSearched = dict.First(x => x.Value % 2 == 0).Key;
            Console.WriteLine(numberSearched);
        }
    }
}
