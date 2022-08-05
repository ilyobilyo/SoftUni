using System;
using System.Collections.Generic;
using System.Linq;

namespace Pirates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Town> towns = new List<Town>();

            while (true)
            {
                string[] townInfo = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);

                if (townInfo[0] == "Sail")
                {
                    break;
                }

                var townName = townInfo[0];
                var townPopulation = int.Parse(townInfo[1]);
                var townGold = int.Parse(townInfo[2]);

                if (towns.Any(x => x.Name == townName))
                {
                    var town = towns.FirstOrDefault(x => x.Name == townName);

                    town.Population += townPopulation;
                    town.Gold += townGold;
                }
                else
                {
                    var town = new Town(townName, townPopulation, townGold);

                    towns.Add(town);
                }

            }

            while (true)
            {
                string[] command = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "End")
                {
                    break;
                }

                var town = towns.FirstOrDefault(x => x.Name == command[1]);

                if (command[0] == "Plunder")
                {
                    var killedPeople = int.Parse(command[2]);
                    var stolenGold = int.Parse(command[3]);

                    town.Population -= killedPeople;

                    town.Gold -= stolenGold;

                    Console.WriteLine($"{town.Name} plundered! {stolenGold} gold stolen, {killedPeople} citizens killed.");

                    if (town.Population <= 0 || town.Gold <= 0)
                    {
                        Console.WriteLine($"{town.Name} has been wiped off the map!");

                        towns.Remove(town);
                    }
                }
                else if (command[0] == "Prosper")
                {
                    var addedGold = int.Parse(command[2]);

                    if (addedGold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");

                        continue;
                    }

                    town.Gold += addedGold;

                    Console.WriteLine($"{addedGold} gold added to the city treasury. {town.Name} now has {town.Gold} gold.");
                }
            }

            if (towns.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

                foreach (var town in towns)
                {
                    Console.WriteLine($"{town.Name} -> Population: {town.Population} citizens, Gold: {town.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

    public class Town
    {
        public Town(string name, int population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }

        public string Name { get; set; }

        public int Population { get; set; }

        public int Gold { get; set; }
    }
}
