using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (!planets.Models.Any(x => x.Name == planetName))
            {
                throw new InvalidOperationException(string
                    .Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            var planet = planets.FindByName(planetName);

            if (unitTypeName == "AnonymousImpactUnit"
                || unitTypeName == "SpaceForces"
                || unitTypeName == "StormTroopers")
            {
                if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
                {
                    throw new InvalidOperationException(String
                        .Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                }

                IMilitaryUnit unit = null;

                switch (unitTypeName)
                {
                    case "AnonymousImpactUnit":
                        {
                            unit = new AnonymousImpactUnit();
                            break;
                        }
                    case "SpaceForces":
                        {
                            unit = new SpaceForces();
                            break;
                        }
                    case "StormTroopers":
                        {
                            unit = new StormTroopers();
                            break;
                        }
                }

                planet.AddUnit(unit);

                planet.Spend(unit.Cost);

                return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
            }
            else
            {
                throw new InvalidOperationException(String
                        .Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (!planets.Models.Any(x => x.Name == planetName))
            {
                throw new InvalidOperationException(string
                    .Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            var planet = planets.FindByName(planetName);

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName == "BioChemicalWeapon"
                || weaponTypeName == "NuclearWeapon"
                || weaponTypeName == "SpaceMissiles")
            {
                IWeapon weapon = null;

                switch (weaponTypeName)
                {
                    case "BioChemicalWeapon":
                        {
                            weapon = new BioChemicalWeapon(destructionLevel);
                            break;
                        }
                    case "NuclearWeapon":
                        {
                            weapon = new NuclearWeapon(destructionLevel);
                            break;
                        }
                    case "SpaceMissiles":
                        {
                            weapon = new SpaceMissiles(destructionLevel);
                            break;
                        }
                }

                planet.AddWeapon(weapon);

                planet.Spend(weapon.Price);

                return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
            }
            else
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.Models.Any(x => x.Name == name))
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }

            planets.AddItem(new Planet(name, budget));

            return String.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models.OrderByDescending(x => x.MilitaryPower)
                .ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var firstPlanet = planets.FindByName(planetOne);
            var secondPlanet = planets.FindByName(planetTwo);

            var isFirstPlanetWin = false;
            var isSecondPlanetWin = false;

            var isFirstHasNuclear = firstPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");
            var isSecondHasNuclear = secondPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");

            var firstNuclear = firstPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon");
            var secondtNuclear = secondPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon");

            var firstCalucatedValue = firstPlanet.Army.Sum(x => x.Cost) + firstPlanet.Weapons.Sum(x => x.Price);
            var secondCalucatedValue = secondPlanet.Army.Sum(x => x.Cost) + secondPlanet.Weapons.Sum(x => x.Price);

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if (isFirstHasNuclear && isSecondHasNuclear)
                {
                    if (firstNuclear.DestructionLevel > secondtNuclear.DestructionLevel)
                    {
                        isFirstPlanetWin = true;
                    }
                    else if (secondtNuclear.DestructionLevel > firstNuclear.DestructionLevel)
                    {
                        isSecondPlanetWin = true;
                    }
                    else
                    {
                        firstPlanet.Spend(firstPlanet.Budget / 2);
                        secondPlanet.Spend(secondPlanet.Budget / 2);

                        return OutputMessages.NoWinner;
                    }
                    
                }
                else if (isFirstHasNuclear)
                {
                    isFirstPlanetWin = true;
                }
                else if (isSecondHasNuclear)
                {
                    isSecondPlanetWin = true;
                }
                else
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);

                    return OutputMessages.NoWinner;
                }
            }
            else if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                isFirstPlanetWin = true;

            }
            else if (secondPlanet.MilitaryPower > firstPlanet.MilitaryPower)
            {
                isSecondPlanetWin = true;

            }

            if (isFirstPlanetWin)
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);

                firstPlanet.Profit(secondPlanet.Budget / 2);
                firstPlanet.Profit(secondCalucatedValue);

                planets.RemoveItem(secondPlanet.Name);

                return String.Format(OutputMessages.WinnigTheWar, firstPlanet.Name, secondPlanet.Name);
            }
            else if (isSecondPlanetWin)
            {
                secondPlanet.Spend(secondPlanet.Budget / 2);

                secondPlanet.Profit(firstPlanet.Budget / 2);
                secondPlanet.Profit(firstCalucatedValue);

                planets.RemoveItem(firstPlanet.Name);

                return String.Format(OutputMessages.WinnigTheWar, secondPlanet.Name, firstPlanet.Name);
            }

            return null;
        }

        public string SpecializeForces(string planetName)
        {
            if (!planets.Models.Any(x => x.Name == planetName))
            {
                throw new InvalidOperationException(string
                    .Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            var planet = planets.FindByName(planetName);

            if (planet.Army.Count <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);

            planet.TrainArmy();

            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
