using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            bool isBalanced = true;
            foreach (var symbol in input)
            {
                bool isValid = symbol == '{' || symbol == '[' || symbol == '(';

                if (isValid)
                {
                    stack.Push(symbol);
                }
                else
                {
                    if (!stack.Any()) //  !!!!
                    {
                        isBalanced = false;
                        break;
                    }

                    if (stack.Peek() == '{' && symbol == '}')
                    {
                        stack.Pop();
                    }
                    else if (stack.Peek() == '[' && symbol == ']')
                    {
                        stack.Pop();
                    }
                    else if (stack.Peek() == '(' && symbol == ')')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
                
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
