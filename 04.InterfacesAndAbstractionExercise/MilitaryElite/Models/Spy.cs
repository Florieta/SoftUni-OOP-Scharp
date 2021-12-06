using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    class Spy : Soldier, ISpy
    {
        public Spy (int id, string firstName, string secondName, int codeNumber)
           : base(id, firstName, secondName)
        {
            this.CodeNumber = codeNumber;
        }
        public int CodeNumber { get; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine
                + $"Code Number: {CodeNumber}";
        }
    }
}
