using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThickness = 200;

        private bool submarineMode;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public bool SubmergeMode 
        {
            get { return submarineMode; }
            private set { submarineMode = false; }
        }


        public override void RepairVessel()
        {
            if (ArmorThickness < InitialArmorThickness)
            {
                ArmorThickness = InitialArmorThickness;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode)
            {
                SubmergeMode = false;
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
            else
            {
                SubmergeMode = true;
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (SubmergeMode)
            {
                sb.AppendLine($" *Submerge mode: ON");

            }
            else
            {
                sb.AppendLine($" *Submerge mode: OFF");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
