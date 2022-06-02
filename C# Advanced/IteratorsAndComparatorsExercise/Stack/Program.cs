using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            string[] input = Console.ReadLine().Split(", ");

            for (int i = 1; i < input.Length; i++)
            {
                stack.Push(int.Parse(input[i]));
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                if (command == "Pop")
                {
                    Console.WriteLine(stack.Pop());
                }

            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
