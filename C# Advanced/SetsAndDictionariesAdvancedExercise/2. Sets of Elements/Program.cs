using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstSetLength = lengths[0];
            int secondSetLength = lengths[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            HashSet<int> finalSet = new HashSet<int>();

            for (int i = 0; i < firstSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());

                firstSet.Add(number);
            }

            for (int i = 0; i < secondSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());

                secondSet.Add(number);
            }

            // !!!! Vrushta vsichki ednakvi elementi sus seconSet v firstSet v reda koito sa podadeni v firstSet !!!!
            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
