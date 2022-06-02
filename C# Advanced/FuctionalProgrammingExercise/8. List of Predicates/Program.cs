using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> numbers = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }

            Func<List<int>, int[], List<int>> findDivisibleNumbers = (numbers, dividers) =>
            {
                List<int> result = new List<int>();
                for (int i = 0; i < numbers.Count; i++)
                {
                    bool isDivide = true;

                    foreach (var divider in dividers)
                    {
                        if (numbers[i] % divider != 0)
                        {
                            isDivide = false;
                            break;
                        }

                    }

                    if (isDivide)
                    {
                        result.Add(numbers[i]);
                    }
                }

                return result;
            };

            Console.WriteLine(string.Join(" ", findDivisibleNumbers(numbers, dividers)));
        }
    }
}
