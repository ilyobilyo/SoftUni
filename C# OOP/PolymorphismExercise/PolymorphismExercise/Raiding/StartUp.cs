using Raiding.Factories;
using Raiding.Models;
using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heros = new List<BaseHero>();

            int numberOfHerosToAdd = int.Parse(Console.ReadLine());

            int createdHeros = 0;

            while (true)
            {
                if (createdHeros == numberOfHerosToAdd)
                {
                    break;
                }

                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (HeroFactory.IsTypeIsValid(heroType))
                {
                    BaseHero currentHero = HeroFactory.GetHeroType(heroName, heroType);
                    heros.Add(currentHero);
                    createdHeros++;
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }

            }

            int bossPower = int.Parse(Console.ReadLine());

            int herosPowersSum = 0;

            foreach (var hero in heros)
            {
                Console.WriteLine(hero.CastAbility());
                herosPowersSum += hero.Power;
            }

            if (herosPowersSum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
