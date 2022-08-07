using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroRecruitment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heros = new List<Hero>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "End")
                {
                    break;
                }
                
                var heroName = command[1];

                if (command[0] == "Enroll")
                {
                    if (heros.Any(x => x.Name == heroName))
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");

                        continue;
                    }

                    Hero hero = new Hero(heroName);

                    heros.Add(hero);
                }
                else if (command[0] == "Learn")
                {
                    var hero = heros.FirstOrDefault(x => x.Name == heroName);
                    var spell = command[2];

                    if (hero == null)
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");

                        continue;
                    }

                    if (hero.Spells.Any(x => x == spell))
                    {
                        Console.WriteLine($"{heroName} has already learnt {spell}.");

                        continue;
                    }

                    hero.Spells.Add(spell);
                }
                else if (command[0] == "Unlearn")
                {
                    var hero = heros.FirstOrDefault(x => x.Name == heroName);
                    var spell = command[2];

                    if (hero == null)
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");

                        continue;
                    }

                    if (!hero.Spells.Any(x => x == spell))
                    {
                        Console.WriteLine($"{heroName} doesn't know {spell}.");

                        continue;
                    }

                    hero.Spells.Remove(spell);
                }

            }

            Console.WriteLine("Heroes:");

            foreach (var hero in heros)
            {
                Console.WriteLine($"== {hero.Name}: {string.Join(", ", hero.Spells)}");
            }
        }
    }

    public class Hero
    {
        public Hero(string name)
        {
            Name = name;

            Spells = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Spells { get; set; }
    }
}
