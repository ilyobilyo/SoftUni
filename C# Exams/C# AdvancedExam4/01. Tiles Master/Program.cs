using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    public class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var secondLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var whiteStack = new Stack<int>(firstLine);
            var greyQueue = new Queue<int>(secondLine);

            var posibleLocations = new Dictionary<string, int>()
            {
                { "Sink", 40 },
                { "Oven", 50 },
                { "Countertop", 60 },
                { "Wall", 70 },
            };

            var usedLocations = new Dictionary<string, int>()
            {
                { "Sink", 0 },
                { "Oven", 0 },
                { "Countertop", 0 },
                { "Wall", 0 },
                { "Floor", 0 },
            };

            while (whiteStack.Count > 0 && greyQueue.Count > 0)
            {
                var whiteTile = whiteStack.Pop();
                var greyTile = greyQueue.Dequeue();

                if (whiteTile == greyTile)
                {
                    var sum = whiteTile + greyTile;

                    var location = posibleLocations.FirstOrDefault(x => x.Value == sum);

                    if (location.Key == null)
                    {
                        usedLocations["Floor"]++;
                    }
                    else
                    {
                        usedLocations[location.Key]++;
                    }
                }
                else
                {
                    whiteTile /= 2;
                    whiteStack.Push(whiteTile);
                    greyQueue.Enqueue(greyTile);
                }
            }

            if (whiteStack.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteStack)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (greyQueue.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyQueue)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var location in usedLocations.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (location.Value > 0)
                {
                    Console.WriteLine($"{location.Key}: {location.Value}");
                }
            }
        }
    }
}
