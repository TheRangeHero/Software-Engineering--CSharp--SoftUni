using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    class Controller : IController

    {
        private readonly EquipmentRepository equipmentRepository;
        private ICollection<IGym> gyms;

        public Controller()
        {
            gyms = new List<IGym>();
            equipmentRepository = new EquipmentRepository();
        }


        //4
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);
            bool isAdded = false;
            //IAthlete athlete = athleteType switch
            //{
            //    nameof(Boxer)=>new Boxer(athleteName,motivation,numberOfMedals),
            //    nameof(Weightlifter)=>new Weightlifter(athleteName,motivation,numberOfMedals),
            //    _ =>throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            //};

            if (athleteType==nameof(Boxer))
            {
                if (gym.GetType().Name == nameof(BoxingGym))
                {
                    IAthlete boxer = new Boxer(athleteName, motivation, numberOfMedals);
                    gym.AddAthlete(boxer);
                    isAdded = true;
                }
            }
            else if (athleteType == nameof(Weightlifter))
            {
                if (gym.GetType().Name == nameof(WeightliftingGym))
                {
                    IAthlete weightLifter = new Weightlifter(athleteName, motivation, numberOfMedals);
                    gym.AddAthlete(weightLifter);
                    isAdded = true;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            if (isAdded)
            {
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }

            return OutputMessages.InappropriateGym;
        }
        //2
        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = equipmentType switch
            {
                nameof(BoxingGloves) => new BoxingGloves(),
                nameof(Kettlebell) => new Kettlebell(),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType)
            };

            equipmentRepository.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);


            //if (equipmentType=="BoxingGloves")
            //{
            //    equipmentRepository.Add(new BoxingGloves());
            //}
            //else if (equipmentType == "WeightLiftingGym")
            //{
            //    equipmentRepository.Add(new Kettlebell());
            //}
            //else
            //{
            //    throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            //}
        }
        //1
        public string AddGym(string gymType, string gymName)
        {
            IGym gym = gymType switch
            {
                nameof(BoxingGym) => new BoxingGym(gymName),
                nameof(WeightliftingGym) => new WeightliftingGym(gymName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidGymType)
            };

            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);

            //if (gymType=="BoxingGym")
            //{
            //    gyms.Add(new BoxingGym(gymName));
            //}
            //else if (gymType == "WeightLiftingGym")
            //{
            //    gyms.Add(new WeightliftingGym(gymName));
            //}
            //else
            //{
            //    throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            //}
        }
        //6
        public string EquipmentWeight(string gymName)
        {

           

            var gym = gyms.FirstOrDefault(g => g.Name == gymName);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }
        //3
        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = equipmentRepository.FindByType(equipmentType);
            if (equipment == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            gym.AddEquipment(equipment);
            equipmentRepository.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }
        //7
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }
        //5
        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);

            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
