using System;

namespace _4._Recursive_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFactorial(n));
        }

        private static int CalcFactorial(int n)
        {
            if (n <= 0)
            {
                return 1;
            }

            return n * CalcFactorial(n - 1);
        }
    }
}
