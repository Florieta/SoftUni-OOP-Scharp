using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateEnum missionState)
        {
            CodeName = codeName;
            MissionState = missionState;
        }

        public string CodeName { get ; }

        public MissionStateEnum MissionState { get; private set; }
        string IMission.CodeName { get ; set; }

        public void CompleteMission()
        {
            this.MissionState = MissionStateEnum.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {MissionState}";
        }
    }
}
