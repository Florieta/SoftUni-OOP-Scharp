using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models = new List<IRacer>();
        public IReadOnlyCollection<IRacer> Models => this.models.AsReadOnly();
      

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            this.models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return this.models.Where(c => c.Username == property).FirstOrDefault();
        }

        public bool Remove(IRacer model)
        {
            return this.models.Remove(model);
        }

        //public override string ToString()
        //{
        //    var sb = new StringBuilder();
        //    foreach (var item in models)
        //    {
        //        sb.AppendLine($"{item.GetType().Name}: {item.Username}");
        //        sb.AppendLine($"--Driving behavior: {item.RacingBehavior}");
        //        sb.AppendLine($"--Driving experience: {item.DrivingExperience}");
        //        sb.AppendLine($"--Car: {item.Car.Make} {item.Car.Model} ({item.Car.VIN})");
        //    }

        //    return sb.ToString().TrimEnd();
        //}
    }
}
