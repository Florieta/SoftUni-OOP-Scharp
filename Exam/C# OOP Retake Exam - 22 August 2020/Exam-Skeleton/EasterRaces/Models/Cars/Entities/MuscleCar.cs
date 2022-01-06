using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int DefaultCubicCentimeters = 5000;
        private const int DefaultMinHorsePower = 400;
        private const int DefaultMaxHorsePower = 600;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, DefaultCubicCentimeters, DefaultMinHorsePower, DefaultMaxHorsePower)
        {
        }
    }
}
