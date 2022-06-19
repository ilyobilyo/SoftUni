using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            double racerOneBehaviorMultiplier;
            double racerTwoBehaviorMultiplier;

            if (racerOne.GetType().Name == "ProfessionalRacer")
            {
                racerOneBehaviorMultiplier = 1.2;
            }
            else
            {
                racerOneBehaviorMultiplier = 1.1;
            }

            if (racerTwo.GetType().Name == "ProfessionalRacer")
            {
                racerTwoBehaviorMultiplier = 1.2;
            }
            else
            {
                racerTwoBehaviorMultiplier = 1.1;
            }

            double racerOneChanceOfWin = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneBehaviorMultiplier;
            double racerTwoChanceOfWin = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoBehaviorMultiplier;

            racerOne.Race(); 
            racerTwo.Race();

            if (racerOneChanceOfWin > racerTwoChanceOfWin)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
        }
    }
}
