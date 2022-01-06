using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int DefaultCubicCentimeters = 3000;
        private const int DefaultMinHorsePower = 250;
        private const int DefaultMaxHorsePower = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, DefaultCubicCentimeters, DefaultMinHorsePower, DefaultMaxHorsePower)
        {
        }
    }
}
