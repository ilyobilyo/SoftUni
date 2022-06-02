using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Contracts
{
    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}
