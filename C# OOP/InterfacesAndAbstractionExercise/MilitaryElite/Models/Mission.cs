using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; set; }
        public string State 
        {
            get
            {
                return this.state;
            }
            set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException("Invalid mission state");
                }

                this.state = value;
            }
        }

        public void CompleteMission()
        {
            if (this.state == "inProgress")
            {
                this.state = "Fineshed";
            }

        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
