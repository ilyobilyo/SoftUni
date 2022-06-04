using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int start = 1;
            int end = 100;

            while (numbers.Count < 10)
            {
                try
                {
                    int number = ReadNumber(start, end);

                    numbers.Add(number);
                    start = number;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            bool IsValid = int.TryParse(input, out int number);

            if (!IsValid)
            {
                throw new ArgumentException("Invalid Number!");
            }

            if (number <= start || number >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }

            return number;
        }
    }
}
