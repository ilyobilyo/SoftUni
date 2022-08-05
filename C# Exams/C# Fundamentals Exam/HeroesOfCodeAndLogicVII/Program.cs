using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var heros = new List<Hero>();

            for (int i = 0; i < n; i++)
            {
                string[] heroInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = heroInfo[0];
                var hp = int.Parse(heroInfo[1]);
                var mp = int.Parse(heroInfo[2]);

                var hero = new Hero(name, hp, mp);

                heros.Add(hero);
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "End")
                {
                    break;
                }

                var hero = heros.FirstOrDefault(x => x.Name == command[1]);

                if (command[0] == "CastSpell")
                {
                    int neededMp = int.Parse(command[2]);
                    string spellName = command[3];

                    CastSpell(hero, neededMp, spellName);
                }
                else if (command[0] == "TakeDamage")
                {
                    int damage = int.Parse(command[2]);
                    string attacker = command[3];

                    TakeDamage(heros, hero, damage, attacker);
                }
                else if (command[0] == "Recharge")
                {
                    int amountMp = int.Parse(command[2]);

                    Recharge(hero, amountMp);
                }
                else if (command[0] == "Heal")
                {
                    int amountHp = int.Parse(command[2]);

                    Heal(hero, amountHp);
                }
            }

            foreach (var hero in heros)
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine($" HP: {hero.Hp}");
                Console.WriteLine($" MP: {hero.Mp}");
            }
        }

        static void CastSpell(Hero hero, int neededMp, string spellName)
        {

            if (hero.Mp >= neededMp)
            {
                hero.Mp -= neededMp;

                Console.WriteLine($"{hero.Name} has successfully cast {spellName} and now has {hero.Mp} MP!");
            }
            else
            {
                Console.WriteLine($"{hero.Name} does not have enough MP to cast {spellName}!");
            }
        }

        static void TakeDamage(List<Hero> heros, Hero hero, int damage, string attacker)
        {

            if (hero.Hp - damage > 0)
            {
                hero.Hp -= damage;

                Console.WriteLine($"{hero.Name} was hit for {damage} HP by {attacker} and now has {hero.Hp} HP left!");
            }
            else
            {
                heros.Remove(hero);

                Console.WriteLine($"{hero.Name} has been killed by {attacker}!");
            }
        }

        static void Recharge(Hero hero, int amountMp)
        {
            int rechargedMp = amountMp;

            if (hero.Mp + amountMp > 200)
            {
                rechargedMp = 200 - hero.Mp;

                hero.Mp = 200;
            }
            else
            {
                hero.Mp += amountMp;
            }

            Console.WriteLine($"{hero.Name} recharged for {rechargedMp} MP!");
        }

        static void Heal(Hero hero, int amountHp)
        {
            int rechargedHp = amountHp;

            if (hero.Hp + amountHp > 100)
            {
                rechargedHp = 100 - hero.Hp;

                hero.Hp = 100;
            }
            else
            {
                hero.Hp += amountHp;
            }

            Console.WriteLine($"{hero.Name} healed for {rechargedHp} HP!");
        }
    }

    public class Hero
    {
        public Hero(string name, int hp, int mp)
        {
            Name = name;
            Hp = hp;
            Mp = mp;
        }

        public string Name { get; set; }

        public int Hp { get; set; }

        public int Mp { get; set; }
    }
}
