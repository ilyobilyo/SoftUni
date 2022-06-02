using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string oddEven = Console.ReadLine();
            List<int> numbers = new List<int>();
            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> even = x => x % 2 == 0;
            Predicate<int> odd = x => x % 2 != 0;
            List<int> result;
            if (oddEven == "even")
            {
                result = numbers.FindAll(even); //FindAll vrushta IEnumaruble (List v slucheq)
            }
            else
            {
                result = numbers.FindAll(odd);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
