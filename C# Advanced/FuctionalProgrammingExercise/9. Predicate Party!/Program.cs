using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            Dictionary<string, Predicate<string>> allFilters = new Dictionary<string, Predicate<string>>();
            while (true)
            {
                string[] command = Console.ReadLine().Split(";");
                if (command[0] == "Print")
                {
                    break;
                }

                string method = command[0];
                string commandCriteria = command[1];
                string criteria = command[2];

                if (method == "Add filter")
                {
                    allFilters.Add(commandCriteria + criteria, GetPredicate(commandCriteria, criteria));
                }
                else
                {
                    allFilters.Remove(commandCriteria + criteria);
                }
            }

            foreach (var pair in allFilters)
            {
                names.RemoveAll(pair.Value);
            }
            Console.WriteLine($"{string.Join(" ", names)}");

        }

        static Predicate<string> GetPredicate(string commandCriteria, string criteria)
        {
            if (commandCriteria == "Starts with")
            {
               return x => x.StartsWith(criteria);
            }
            else if (commandCriteria == "Ends with")
            {
                return x => x.EndsWith(criteria);
            }
            else if (commandCriteria == "Length")
            {
                return x => x.Length == int.Parse(criteria);
            }
            else
            {
                return x => x.Contains(criteria);
            }
        }
    }
}
