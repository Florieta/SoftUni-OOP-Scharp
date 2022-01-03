using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int ProRacerDrivingExperience = 30;
        private const string ProRacerRacingBehavior = "strict";
        public ProfessionalRacer(string username, ICar car) 
            : base(username, ProRacerRacingBehavior, ProRacerDrivingExperience, car)
        {
        }
        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 10;
        }
    }
}
