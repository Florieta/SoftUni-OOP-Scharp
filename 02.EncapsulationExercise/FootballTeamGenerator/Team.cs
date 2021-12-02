using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;


        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }
        public int GetTeamRating => TeamRating();
        public void AddPlayer (Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer (string name)
        {
            var player = players.FirstOrDefault(x => x.Name == name);
            if (player is null)
            {
                throw new InvalidOperationException($"Player {name} is not in {this.Name} team.");
            }
            this.players.Remove(player);
        }

        private int TeamRating()
        {
            var rating = 0;

            foreach (var player in players)
            {
                rating += player.GetSkillLevel;
            }

            if (rating == 0)
            {
                return 0;
            }
            var result = rating / players.Count;

            return result;
        }
    }
}
