using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string[], int, List<string>> sortedNames = (array, length) =>
            {
                List<string> result = new List<string>();
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length <= length)
                    {
                        result.Add(array[i]);
                    }
                }

                return result;
            };

            List<string> result = sortedNames(names, length);

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
