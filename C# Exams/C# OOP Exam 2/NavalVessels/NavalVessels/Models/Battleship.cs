using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmorThickness = 300;

        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public bool SonarMode 
        {
            get { return sonarMode; }
            private set { sonarMode = false; }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < InitialArmorThickness)
            {
                ArmorThickness = InitialArmorThickness;
            }
        }

        public void ToggleSonarMode()
        {
            if (SonarMode)
            {
                SonarMode = false;
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
            else
            {
                SonarMode = true;
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (SonarMode)
            {
                sb.AppendLine($" *Sonar mode: ON");

            }
            else
            {
                sb.AppendLine($" *Sonar mode: OFF");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
