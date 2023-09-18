using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private IRepository<IPilot> pilotRepository;
        private IRepository<IRace> raceRepository;
        private IRepository<IFormulaOneCar> formulaOneCarRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            formulaOneCarRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {

            if (formulaOneCarRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
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
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            formulaOneCarRepository.Add(car);

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }
        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            IRace race = new Race(raceName, numberOfLaps);

            raceRepository.Add(race);
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = formulaOneCarRepository.FindByName(carModel);
            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (car == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }


            pilot.AddCar(car);
            formulaOneCarRepository.Remove(car);
            string carType = car.GetType().Name;

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, carType, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            IRace race = raceRepository.FindByName(raceName);
            if (race==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (pilot==null||pilot.CanRace==false || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            race.AddPilot(pilot);

            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);


        }
        public string StartRace(string raceName)
        {

            IRace race = raceRepository.FindByName(raceName);
            if (race==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (race.Pilots.Count<3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> orderedPilots = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            race.TookPlace = true;
            orderedPilots[0].WinRace();


            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {orderedPilots[0].FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {orderedPilots[1].FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {orderedPilots[2].FullName} is third in the {raceName} race.");

            return sb.ToString().Trim();
        }

        public string PilotReport()
        {
            List<IPilot> pilots = pilotRepository.Models.OrderByDescending(p => p.NumberOfWins).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var pilot in pilots)
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            List<IRace> races = raceRepository.Models.Where(r => r.TookPlace).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var race in races)
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().Trim();
        }

    }
}
