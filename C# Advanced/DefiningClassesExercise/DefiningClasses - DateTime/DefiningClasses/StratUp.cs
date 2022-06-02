using System;

namespace DefiningClasses
{
    class StratUp
    {
        static void Main(string[] args)
        {
            string firstDateAsString = Console.ReadLine();
            string secondDateAsString = Console.ReadLine();

            Console.WriteLine(DateModifier.CalculateDifference(firstDateAsString, secondDateAsString));
        }
    }
}
