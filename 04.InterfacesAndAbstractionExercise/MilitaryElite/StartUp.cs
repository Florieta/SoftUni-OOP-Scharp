using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using MilitaryElite.Enumerations;

namespace MilitaryElite
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<ISoldier> result = new List<ISoldier>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split().ToArray();
                string soldierType = tokens[0];
                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];
                
                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    result.Add(new Private(id, firstName, lastName, salary));
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(tokens[4]);
                    result.Add(new Spy(id, firstName, lastName, codeNumber));

                }
                else if (soldierType == "LeutenantGeneral")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    List<IPrivate> privates = new List<IPrivate>();
                    foreach (var currentId in tokens[5..]) 
                    {
                        IPrivate currentPrivate = (IPrivate)result.FirstOrDefault(x => x.Id == int.Parse(currentId));
                        privates.Add(currentPrivate);
                    }
                    result.Add(new LieutenantGeneral(id, firstName, lastName, salary, privates));
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    Enum.TryParse(tokens[5], false, out SoldierCorpsEnum corp);
                    if (corp == default)
                    {
                        continue;
                    }

                    List<IRepair> repairs = new List<IRepair>();
                    for (int i = 0; i < tokens[6..].Length; i+=2)
                    {
                        var partName = tokens[i];
                        var workedHours = int.Parse(tokens[i + 1]);

                        repairs.Add(new Repair(partName, workedHours));
                    }
                    result.Add(new Engineer(id, firstName, lastName, salary, corp, repairs));
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    Enum.TryParse(tokens[5], false, out SoldierCorpsEnum corp);
                    if (corp == default)
                    {
                        continue;
                    }
                    List<IMission> missions = new List<IMission>();
                    for (int i = 0; i < tokens[6..].Length; i++)
                    {
                        var missionState = tokens[i + 1];
                        if (missionState == "inProgress" && missionState == "Finished")
                        {
                            continue;
                        }

                        var missionName = tokens[i];
                        Enum.TryParse(missionState, false, out MissionStateEnum state);
                        if (state != default)
                        {
                            IMission mission = new Mission(missionName, state);
                            missions.Add(mission);
                        }
                        
                    }

                    result.Add(new Commando(id, firstName, lastName, salary, corp, missions));
                }
            }

            foreach (var soldier in result)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
