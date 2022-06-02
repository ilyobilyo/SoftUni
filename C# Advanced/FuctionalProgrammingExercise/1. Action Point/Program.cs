using System;
using System.Linq;

namespace _1._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Action<string[]> print = x => Console.WriteLine(string.Join(Environment.NewLine, input));

            print(input);
            
        }
    }
}
