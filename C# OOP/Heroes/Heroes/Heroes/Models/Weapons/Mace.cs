using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        public Mace(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (this.durability == 0)
            {
                return 0;
            }

            this.durability -= 1;


            return 25;
        }
    }
}
