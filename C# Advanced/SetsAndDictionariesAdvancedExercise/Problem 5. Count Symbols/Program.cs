using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> dictionary = new SortedDictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];

                if (!dictionary.ContainsKey(currChar))
                {
                    dictionary.Add(currChar, 1);
                }
                else
                {
                    dictionary[currChar]++;
                }
            }

            foreach (var pair in dictionary)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}
