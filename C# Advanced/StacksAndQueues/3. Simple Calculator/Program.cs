using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>();
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            while (true)
            {
                if (stack.Count < 1)
                {
                    break;
                }

                int currNumber = int.Parse(stack.Pop());
                if (stack.Count > 0)
                {
                    char operation = char.Parse(stack.Pop());
                    if (operation == '+')
                    {
                        sum += currNumber;
                    }
                    else if (operation == '-')
                    {
                        sum -= currNumber;
                    }
                }
                else
                {
                    sum += currNumber;
                }
                
            }

            Console.WriteLine(sum);
            Console.WriteLine();
        }
    }
}
