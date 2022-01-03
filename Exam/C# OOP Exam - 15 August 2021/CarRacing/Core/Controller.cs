using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;
        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;

            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            this.cars.Add(car);

            return string.Format(OutputMessages.SuccessfullyAddedCar, car.Make, car.Model, car.VIN);

        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer;

            var car = this.cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            this.racers.Add(racer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = this.racers.FindBy(racerOneUsername);
            var racerTwo = this.racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(racerOne, racerTwo);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            var ordered = this.racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username).ToList();
            foreach (var racer in ordered)
            {
                sb.Append(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
