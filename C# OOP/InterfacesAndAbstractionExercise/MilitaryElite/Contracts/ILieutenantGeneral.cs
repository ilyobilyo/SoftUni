using MilitaryElite.Models;
using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
       IReadOnlyCollection<ISoldier> Privates { get;}
        void AddISoldiers(ISoldier p);
    }
}
