using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private const int MinValue = 0;

        private const int MaxValue = 100;

        private string name;

        private int endurance;

        private int sprint;

        private int dribble;

        private int passing;

        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
           
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

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                ValidateStat(value, nameof(Endurance));

                this.endurance = value;
            }

        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                ValidateStat(value, nameof(Dribble));

                this.dribble = value;
            }
        }

        public int Sprint 
        {
            get => this.sprint;
            private set
            {
                ValidateStat(value, nameof(Sprint));

                this.sprint = value;
            }
        }

        public int Passing 
        {
            get => this.passing;
            private set
            {
                ValidateStat(value, nameof(Passing));

                this.passing = value;
            }
        }

        public int Shooting 
        {
            get => this.shooting;
            private set
            {
                ValidateStat(value, nameof(Shooting));

                this.shooting = value;
            }
        }

        public int GetSkillLevel
        {
            get => SkillLevel();
        }
        public int SkillLevel()
        {
            double countOfPlayerSkill = 5.0;
            return (int)Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / countOfPlayerSkill);
        }

        private void ValidateStat(int value, string statName)
        {
            if (value < MinValue || value > MaxValue)
            {
                
                throw new ArgumentException($"{statName} should be between {MinValue} and {MaxValue}.");
            }
        }
    }
}
