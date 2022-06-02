using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public abstract class Identifiable
    {
        protected Identifiable(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public string GetLastNumbers(int lastDigitsLength)
        {
            int reverseIndex = Id.Length - lastDigitsLength;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < lastDigitsLength; i++)
            {
                sb.Append(Id[reverseIndex]);
                reverseIndex++;
            }

            return sb.ToString();
        }
        
    }
}
