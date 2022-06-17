using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = carRepository.FindByName(carModel);

            if (pilot == null || pilot.CanRace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage,pilotName));
            }

            if (car == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage,carModel));
            }

            pilot.AddCar(car);
            carRepository.Remove(car);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            IRace race = raceRepository.FindByName(raceName);


            if (pilot == null || !pilot.CanRace || race.Pilots.Any(x => x.FullName == pilotFullName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.Pilots.Add(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            IFormulaOneCar car = null;

            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar,type));
            }

            carRepository.Add(car);

            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);

            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pilot in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var race in raceRepository.Models.Where(x => x.TookPlace))
            {
               sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            race.TookPlace = true;
            Dictionary<double, IPilot> pilotsRanking = new Dictionary<double, IPilot>();

            foreach (var pilot in race.Pilots)
            {
                pilotsRanking.Add(pilot.Car.RaceScoreCalculator(race.NumberOfLaps), pilot);
            }

            List<IPilot> top3 = new List<IPilot>();
            int count = 0;
            foreach (var item in pilotsRanking.OrderByDescending(x => x.Key))
            {
                if (count == 3)
                {
                    break;
                }

                top3.Add(item.Value);
                count++;
            }

            top3[0].WinRace();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, top3[0].FullName, race.RaceName));
            sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, top3[1].FullName, race.RaceName));
            sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, top3[2].FullName, race.RaceName));

            return sb.ToString().TrimEnd();
        }
    }
}
