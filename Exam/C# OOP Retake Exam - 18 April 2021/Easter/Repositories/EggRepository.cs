using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    class EggRepository : IRepository<IEgg>
    {
        private readonly IDictionary<string, IEgg> eggByModel;

        public EggRepository()
        {
            eggByModel = new Dictionary<string, IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => this.eggByModel.Values.ToList();

        public void Add(IEgg model)
        {
            if (!eggByModel.ContainsKey(model.Name))
            {
                eggByModel.Add(model.Name, model);
            }

        }

        public IEgg FindByName(string name)
        {
            IEgg egg = null;
            if (eggByModel.ContainsKey(name))
            {
                egg = eggByModel[name];
            }
            else
            {
                egg = null;
            }
            return egg;
        }

        public bool Remove(IEgg model)
        {
            return eggByModel.Remove(model.Name);
        }
    }
}
