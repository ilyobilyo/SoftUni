using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                numbers.Push(inputNumbers[i]);
            }


            while (true)
            {
                string[] command = Console.ReadLine().Split();


                if (command[0].ToLower() == "end")
                {
                    break;
                }
                else if (command[0].ToLower() == "add")
                {
                    numbers.Push(int.Parse(command[1]));
                    numbers.Push(int.Parse(command[2]));
                }
                else if (command[0].ToLower() == "remove")
                {
                    int numbersToRemove = int.Parse(command[1]);
                    if (numbersToRemove <= numbers.Count)
                    {
                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            numbers.Pop();
                        }
                    }
                    
                }
            }

            Console.WriteLine("Sum: " + numbers.Sum());
        }
    }
}
