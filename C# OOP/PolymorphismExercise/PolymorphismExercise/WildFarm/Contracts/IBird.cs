using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Contracts
{
    public interface IBird : IAnimal
    {
        double WingSize { get; }
    }
}
