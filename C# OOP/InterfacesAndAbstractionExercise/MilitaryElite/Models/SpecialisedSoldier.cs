using MilitaryElite.Contracts;
using System;
using System.Text;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corp;

        public SpecialisedSoldier(string id, string firstName,
            string lastName, decimal salary, string corp) : base(id, firstName, lastName, salary)
        {
            Corp = corp;
        }

        public string Corp 
        {
            get
            {
                return this.corp;
            }
            set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("Invalid corps");
                }

                corp = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corp}");

            return sb.ToString().TrimEnd();
        }
    }
}
