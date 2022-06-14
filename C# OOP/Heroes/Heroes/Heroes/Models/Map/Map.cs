using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> barbarians = players.Where(x => x.GetType().Name.ToLower() == "barbarian").ToList();
            List<IHero> knights = players.Where(x => x.GetType().Name.ToLower() == "knight").ToList();


            while (knights.Any(x => x.IsAlive) && barbarians.Any(x => x.IsAlive))
            {
                foreach (var barbarian in barbarians.Where(x => x.IsAlive))
                {
                    foreach (var knight in knights.Where(x => x.IsAlive && x.Weapon != null))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                foreach (var knight in knights.Where(x => x.IsAlive))
                {
                    foreach (var barbarian in barbarians.Where(x => x.IsAlive && x.Weapon != null))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }
            }

            if (knights.Any(x => x.IsAlive))
            {
                return $"The knights took {knights.Count(x => x.IsAlive == false)} casualties but won the battle.";
            }
            else
            {
                return $"The barbarians took {barbarians.Count(x => x.IsAlive == false)} casualties but won the battle.";
            }

        }
    }
}
