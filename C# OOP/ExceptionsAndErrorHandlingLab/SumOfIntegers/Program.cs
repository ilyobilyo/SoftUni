using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            string[] input = Console.ReadLine().Split(' ');

            for (int i = 0; i < input.Length; i++)
            {
                string currElement = input[i];

                try
                {
                    if (ValidateElement(currElement))
                    {
                        numbers.Add(int.Parse(currElement));
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{currElement}' processed - current sum: {numbers.Sum()}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {numbers.Sum()}");
        }

        static bool ValidateElement(string element)
        {

            bool isInteger = int.TryParse(element, out int currNumber);
            bool isDecimal = decimal.TryParse(element, out decimal currDecimal);
            bool isLong = long.TryParse(element,out long currLong);

            if (isInteger)
            {
                return true;
            }
            else
            {
                if (currDecimal > int.MaxValue || currDecimal < int.MinValue)
                {
                    throw new OverflowException($"The element '{element}' is out of range!");
                }
                else
                {
                    throw new FormatException($"The element '{element}' is in wrong format!");
                }
            }
        }
    }
}
