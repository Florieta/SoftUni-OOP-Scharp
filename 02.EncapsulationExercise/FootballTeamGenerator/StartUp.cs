using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            List<Team> teams = new List<Team>();
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(";");
                string command = tokens[0];
                string teamName = tokens[1];
                string playerName = default;
                switch (command)
                {
                    case "Add" when teams.Any(x => x.Name == teamName):
                        playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);
                        try
                        {
                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            teams.FirstOrDefault(x => x.Name == teamName).AddPlayer(player);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                        break;
                    case "Remove" when teams.Any(x => x.Name == teamName):
                        try
                        {
                           playerName = tokens[2];

                            teams.First(x => x.Name == teamName).RemovePlayer(playerName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;

                        }
                        break;
                    case "Team":
                        teams.Add(new Team(teamName));
                        break;
                    case "Rating" when teams.Any(x => x.Name == teamName):
                        Team team = teams.First(x => x.Name == teamName);
                        Console.WriteLine($"{teamName} - { team.GetTeamRating}");
                        break;
                    default:
                        Console.WriteLine($"Team {teamName} does not exist.");
                        break;
                }
            }
        }
    }
}
