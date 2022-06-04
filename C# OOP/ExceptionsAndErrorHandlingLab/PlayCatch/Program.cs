using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int count = 0;
            while (true)
            {
                if (count == 3)
                {
                    break;
                }

                string[] command = Console.ReadLine().Split();

                try
                {
                    if (command[0] == "Replace")
                    {
                        string indexAsString = command[1];
                        string element = command[2];

                        Replace(indexAsString, element, numbers);
                    }
                    else if (command[0] == "Print")
                    {
                        string startIndexAsString = command[1];
                        string endIndexAsString = command[2];

                        Print(startIndexAsString, endIndexAsString, numbers);
                    }
                    else if (command[0] == "Show")
                    {
                        string indexAsString = command[1];

                        Show(indexAsString, numbers);
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    count++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        static void Replace(string indexAsString, string element, int[] numbers)
        {
            bool isElementValid = int.TryParse(element, out int integer);
            bool isIndexValid = int.TryParse(indexAsString, out int index);

            if (!isElementValid || !isIndexValid)
            {
                throw new ArgumentException("The variable is not in the correct format!");
            }
            else if (!IsIndexValid(index, numbers))
            {
                throw new ArgumentException("The index does not exist!");
            }

            numbers[index] = integer;
        }

        static void Print(string startIndexAsString, string endIndexAsString, int[] numbers)
        {
            List<int> printNumbers = new List<int>();

            bool isStartIndexValidNumber = int.TryParse(startIndexAsString, out int startIndex);
            bool isEndIndexValidNumber = int.TryParse(endIndexAsString, out int endIndex);

            if (!isStartIndexValidNumber || !isEndIndexValidNumber)
            {
                throw new ArgumentException("The variable is not in the correct format!");
            }
            else if (!IsIndexValid(startIndex, numbers) || !IsIndexValid(endIndex, numbers))
            {
                throw new ArgumentException("The index does not exist!");
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                printNumbers.Add(numbers[i]);
            }

            Console.WriteLine(string.Join(", ", printNumbers));

        }

        static void Show(string indexAsString, int[] numbers)
        {
            bool isIndexAInteger = int.TryParse(indexAsString, out int index);

            if (!isIndexAInteger)
            {
                throw new ArgumentException("The variable is not in the correct format!");
            }
            else if (!IsIndexValid(index, numbers))
            {
                throw new ArgumentException("The index does not exist!");
            }

            Console.WriteLine(numbers[index]);
        }

        static bool IsIndexValid(int index, int[] numbers)
            => index >= 0 && index < numbers.Length;
    }
}
