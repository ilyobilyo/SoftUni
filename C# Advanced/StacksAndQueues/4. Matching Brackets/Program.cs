using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> openBrackets = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openBrackets.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startIndex = openBrackets.Pop();
                    Console.WriteLine(expression.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
