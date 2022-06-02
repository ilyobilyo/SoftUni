using System;
using System.Linq;

namespace _2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Action<string> printer = x => Console.WriteLine($"Sir {x}");
            var names = input.ToList();
            names.ForEach(printer);
        }
    }
}
