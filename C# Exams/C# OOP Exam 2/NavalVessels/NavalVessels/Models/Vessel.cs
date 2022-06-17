using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThicknes;
        private double mainWeaponCaliber;
        private double speed;
        private ICollection<string> targets;

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThicknes)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThicknes;
            targets = new List<string>();
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
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidVesselName));
                }

                name = value;
            }
        }

        public ICaptain Captain
        {
            get
            {
                return captain;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCaptainToVessel));
                }

                captain = value;
            }
        }
        public double ArmorThickness
        {
            get { return armorThicknes; }
            set { armorThicknes = value; }
        }

        public double MainWeaponCaliber
        {
            get { return mainWeaponCaliber; }
            protected set { mainWeaponCaliber = value; }
        }

        public double Speed
        {
            get { return speed; }
            protected set { speed = value; }
        }

        public ICollection<string> Targets => targets;

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));
            }

            if (target.ArmorThickness - this.MainWeaponCaliber < 0)
            {
                target.ArmorThickness = 0;
            }
            else
            {
                target.ArmorThickness -= this.MainWeaponCaliber;
            }

            targets.Add(target.Name);
        }

        public abstract void RepairVessel();


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");
            if (targets.Count == 0)
            {
                sb.AppendLine($"*Targets: None");
            }
            else
            {
                sb.AppendLine($"*Targets: {string.Join(", ", targets)}");

            }

            return sb.ToString().TrimEnd();
        }
    }
}
