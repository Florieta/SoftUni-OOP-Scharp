using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        public WeightliftingGym(string name) : base(name, 20)
        {
        }
    }
}
