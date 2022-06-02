using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public string Birthdate { get; set; }

        public string GetBirthYear()
        {
            string[] dayMonthYear = Birthdate.Split('/', StringSplitOptions.RemoveEmptyEntries);

            return dayMonthYear[2];
        }
    }
}
