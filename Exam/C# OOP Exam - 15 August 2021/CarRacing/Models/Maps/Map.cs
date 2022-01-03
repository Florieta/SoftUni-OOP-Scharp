using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps.Contracts
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

            racerOne.Race();
            racerTwo.Race();

            double racerOneRacingBehaviorMultiplier = 0; 
            double racerTwoRacingBehaviorMultiplier = 0; 
            
            if (racerOne.RacingBehavior == "strict")
            {
                racerOneRacingBehaviorMultiplier = 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                racerOneRacingBehaviorMultiplier = 1.1;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                racerTwoRacingBehaviorMultiplier = 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                racerTwoRacingBehaviorMultiplier = 1.1;
            }

            double racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneRacingBehaviorMultiplier;
            double racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoRacingBehaviorMultiplier;

            if (racerOneChanceOfWinning > racerTwoChanceOfWinning)
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
