using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    public static class HeroFactory
    {
        public static BaseHero GetHeroType(string name, string heroType)
        {
            BaseHero hero = null;

            if (heroType == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (heroType == "Druid")
            {
                hero = new Druid(name);
            }
            else if (heroType == "Warrior")
            {
                hero = new Warrior(name);
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(name);
            }

            return hero;
        }

        public static bool IsTypeIsValid(string type)
        {
            return type == "Paladin" || type == "Druid"
                || type == "Warrior" || type == "Rogue";
        }
    }
}
