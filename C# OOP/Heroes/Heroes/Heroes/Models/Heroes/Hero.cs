using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }

                health = value;
            }
        }

        public int Armour
        {
            get
            {
                return armour;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }

                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get
            {
                return weapon;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                weapon = value;
            }
        }

        public bool IsAlive
            => health > 0;

        public void AddWeapon(IWeapon weapon)
        {
            if (this.weapon == null)
            {
                this.weapon = weapon;
            }
        }

        public void TakeDamage(int points)
        {
            if (this.armour - points > 0)
            {
                this.armour -= points;
            }
            else
            {
                int diff = Math.Abs(this.armour - points);
                this.armour = 0;
                this.health -= diff;
                if (this.health < 0)
                {
                    this.health = 0;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Name}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armour: {this.Armour}");
            if (this.Weapon == null)
            {
                sb.AppendLine($"--Weapon: Unarmed");
            }
            else
            {
                sb.AppendLine($"--Weapon: {this.Weapon.Name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
