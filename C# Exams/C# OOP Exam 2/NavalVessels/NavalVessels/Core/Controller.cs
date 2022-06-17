using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private IRepository<IVessel> vessels;
        private ICollection<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            IVessel vessel = vessels.FindByName(selectedVesselName);

            if (captain == null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (vessel.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            captain.AddVessel(vessel);
            vessel.Captain = captain;

            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = vessels.FindByName(attackingVesselName);
            IVessel defendingVessel = vessels.FindByName(defendingVesselName);

            if (attackingVessel == null || defendingVessel == null)
            {
                //throw new Exception(String.Format(OutputMessages.VesselNotFound, attackingVessel));
                return String.Format(OutputMessages.VesselNotFound, attackingVessel);
            }

            if (attackingVessel.ArmorThickness == 0 || defendingVessel.ArmorThickness == 0)
            {
                if (attackingVessel.ArmorThickness == 0)
                {
                    return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVessel);

                }
            }

            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == captainFullName);


            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            if (captains.Any(x => x.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            ICaptain captain = new Captain(fullName);
            captains.Add(captain);

            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = null;

            if (vessels.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return String.Format(OutputMessages.InvalidVesselType);
            }

            vessels.Add(vessel);
            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();
            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel.GetType().Name == "Battleship")
            {
                IBattleship battleship = (IBattleship)vessel;
                battleship.ToggleSonarMode();

                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else if (vessel.GetType().Name == "Submarine")
            {
                ISubmarine submarine = (ISubmarine)vessel;
                submarine.ToggleSubmergeMode();

                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }

            return String.Format(OutputMessages.VesselNotFound, vesselName);
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            return vessel.ToString();
        }
    }
}
