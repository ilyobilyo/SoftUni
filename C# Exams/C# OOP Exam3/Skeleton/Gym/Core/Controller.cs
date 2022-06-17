using Gym.Core.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Athletes;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private readonly ICollection<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            bool isAdded = false;
            if (athleteType == "Boxer")
            {

                if (gym.GetType().Name == "BoxingGym")
                {
                    isAdded = true;
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);
                }

            }
            else if (athleteType == "Weightlifter")
            {

                if (gym.GetType().Name == "WeightliftingGym")
                {
                    isAdded = true;
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            if (isAdded)
            {
                gym.AddAthlete(athlete);
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }

            return OutputMessages.InappropriateGym;
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment currentEquipment = null;

            if (equipmentType == "BoxingGloves")
            {
                currentEquipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                currentEquipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            equipment.Add(currentEquipment);
            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;

            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            gyms.Add(gym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment currentEqupment = equipment.FindByType(equipmentType);

            if (currentEqupment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            gym.AddEquipment(currentEqupment);
            equipment.Remove(currentEqupment);

            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);

            gym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
