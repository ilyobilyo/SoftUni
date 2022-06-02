using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<ISoldier> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates => privates;

        public void AddISoldiers(ISoldier privateToAdd)
        {
            privates.Add(privateToAdd);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var priv in privates)
            {
                sb.AppendLine($"  {priv}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
