using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Contracts
{
    interface IFeline : IMammal
    {
        string Breed { get; }
    }
}
