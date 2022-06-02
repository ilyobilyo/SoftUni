using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary, string corp) : base(id, firstName, lastName, salary, corp)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => this.missions;

        public void AddIMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            foreach (var mission in missions)
            {
                sb.AppendLine($"  {mission}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
