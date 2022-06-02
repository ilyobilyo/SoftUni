using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = n => char.IsUpper(n[0]); // !!

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(checker).ToArray(); // Samo pisha promenlivata na Func-a !

            foreach (var word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
}
