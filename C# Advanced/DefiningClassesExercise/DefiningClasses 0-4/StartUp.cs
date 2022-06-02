using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            //03. Oldest Family Member
            //Family family = new Family();

            //for (int i = 0; i < n; i++)
            //{
            //    string[] input = Console.ReadLine().Split();
            //    string name = input[0];
            //    int age = int.Parse(input[1]);

            //    family.AddMember(new Person(name, age));
            //}

            //if (family.FamilyList.Count > 0)
            //{
            //    Console.WriteLine(family.GetOldestMember().ToString());
            //}




            //04. Opinion Poll

            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                if (age > 30)
                {
                    persons.Add(new Person(name, age));
                }
            }

            foreach (Person person in persons.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
