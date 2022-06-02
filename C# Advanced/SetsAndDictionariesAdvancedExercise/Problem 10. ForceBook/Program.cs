using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_10._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var forceData = new Dictionary<string, SortedSet<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }

                if (input.Contains('|'))
                {
                    string[] command = input.Split(" | ");

                    string forceSide = command[0];
                    string username = command[1];

                    if (!forceData.ContainsKey(forceSide))
                    {
                        forceData.Add(forceSide, new SortedSet<string>());
                    }

                    // Trqbva da ima samo v edin set edno takova ime za tova proverqvam dali veche ne imam takova ime !!!!
                    if (!forceData.Any(x => x.Value.Any(r => r == username)))
                    {
                        forceData[forceSide].Add(username);
                    }
                }
                else
                {
                    string[] command = input.Split(" -> ");

                    string forceSide = command[1];
                    string username = command[0];


                    if (forceData.Any(x => x.Value.Any(r => r == username)))
                    {
                        forceData.First(x => x.Value.Remove(username));

                        if (!forceData.ContainsKey(forceSide))
                        {
                            forceData.Add(forceSide, new SortedSet<string>());
                        }

                        forceData[forceSide].Add(username);
                    }
                    else
                    {
                        if (!forceData.ContainsKey(forceSide))
                        {
                            forceData.Add(forceSide, new SortedSet<string>());
                        }

                        forceData[forceSide].Add(username);
                    }

                    Console.WriteLine($"{username} joins the {forceSide} side!");
                }
            }

            foreach (var side in forceData.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                    foreach (var user in side.Value)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
