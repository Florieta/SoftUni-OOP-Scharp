using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enumerations;

namespace MilitaryElite.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; set; }

        public MissionStateEnum MissionState { get; }

        public void CompleteMission();
    }
}
