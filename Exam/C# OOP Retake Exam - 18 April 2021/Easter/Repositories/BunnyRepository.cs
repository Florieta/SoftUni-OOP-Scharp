using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly IDictionary<string, IBunny> bunnyByModel;

        public BunnyRepository()
        {
            bunnyByModel = new Dictionary<string, IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => this.bunnyByModel.Values.ToList();

        public void Add(IBunny model)
        {
            if (!bunnyByModel.ContainsKey(model.Name))
            {
                bunnyByModel.Add(model.Name, model);
            }
            
        }

        public IBunny FindByName(string name)
        {
            IBunny bunny = null;
            if (bunnyByModel.ContainsKey(name))
            {
                bunny = bunnyByModel[name];
            }
            else
            {
                bunny = null;
            }
            return bunny;
        }

        public bool Remove(IBunny model)
        {
            return bunnyByModel.Remove(model.Name);
        }
    }
}
