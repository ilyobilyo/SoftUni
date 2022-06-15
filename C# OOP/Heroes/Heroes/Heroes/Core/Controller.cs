using Heroes.Core.Contracts;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Weapons;
using Heroes.Models.Map;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private readonly HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);
            IWeapon weapon = weapons.FindByName(weaponName);

            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);

            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = null;

            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            if (type != "Barbarian" && type != "Knight")
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            string result = string.Empty;

            if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);

                result = $"Successfully added Barbarian {name} to the collection.";
            }
            else if (type == "Knight")
            {
                hero = new Knight(name, health, armour);

                result = $"Successfully added Sir {name} to the collection.";
            }

            heroes.Add(hero);

            return result;
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon = null;

            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
            
            if (type != "Mace" && type != "Claymore")
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            if (type == "Mace")
            {
                weapon = new Mace(name, durability);
            }
            else
            {
                weapon = new Claymore(name, durability);
            }

            weapons.Add(weapon);

            return $"A {type.ToLower()} {weapon.Name} is added to the collection.";
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in heroes.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Name))
            {
                sb.AppendLine($"{hero}");
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            Map map = new Map();
            return map.Fight(heroes.Models.ToList());
        }
    }
}
