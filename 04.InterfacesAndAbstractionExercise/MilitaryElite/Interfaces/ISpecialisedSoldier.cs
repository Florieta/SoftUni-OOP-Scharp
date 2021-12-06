using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enumerations;

namespace MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier
    {
        public SoldierCorpsEnum Corp { get; }
    }
}
