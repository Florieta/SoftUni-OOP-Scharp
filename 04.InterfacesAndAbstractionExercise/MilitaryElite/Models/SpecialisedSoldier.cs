using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string secondName, decimal salary, SoldierCorpsEnum corp) 
            : base(id, firstName, secondName, salary)
        {
            this.Corp = corp;
        }

        public SoldierCorpsEnum Corp { get; }

        public override string ToString()
        {
            return base.ToString()
                +
                Environment.NewLine
                + $"Corps: {Corp}";
        }
    }
}
