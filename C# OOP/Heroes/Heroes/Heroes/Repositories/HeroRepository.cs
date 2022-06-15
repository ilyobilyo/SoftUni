using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Repositories.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> repository = new List<IHero>();
        public IReadOnlyCollection<IHero> Models => repository.AsReadOnly();

        public void Add(IHero model)
        {
            repository.Add(model);
        }

        public IHero FindByName(string name)
        {
            return repository.FirstOrDefault(x => x.Name == name);
        }


        public bool Remove(IHero model)
        {
            
             return  repository.Remove(model);
             
        }

    }
}
