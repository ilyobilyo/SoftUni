using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    class Family
    {
        public Family()
        {
            FamilyList = new List<Person>();
        }
        public List<Person> FamilyList { get; set; }

        public void AddMember(Person member)
        {
            FamilyList.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = new Person(int.MinValue);

            for (int i = 0; i < FamilyList.Count; i++)
            {
                if (FamilyList[i].Age > oldestPerson.Age)
                {
                    oldestPerson = FamilyList[i];
                }
            }

            return oldestPerson;
        }
    }
}
