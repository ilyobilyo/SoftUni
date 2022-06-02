using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        int age;
        string name;
        public Person(string name, int age)
        {
            this.Name = name;
            this.age = age;
        }

        public string Name { get; set; }
        public int Age
        {
            get
            {
                if (age > 0)
                {
                    return this.age;
                }
                else
                {
                    throw new Exception();
                }
            }
            set
            {
                if (age > 0)
                {
                    Age = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
