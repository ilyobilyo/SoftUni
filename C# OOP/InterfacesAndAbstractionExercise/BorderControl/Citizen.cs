using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : Identifiable, IBirthable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate) : base(id)
        {
            Name = name;
            Age = age;
            Birthdate = birthdate;
            Food = 0;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }

        public string GetBirthYear()
        {
            string[] dayMonthYear = Birthdate.Split('/', StringSplitOptions.RemoveEmptyEntries);

            return dayMonthYear[2];
        }
    }
}
