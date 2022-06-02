using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> studentsList = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Student currStudent = new Student(input[0], int.Parse(input[1]));
                studentsList.Add(currStudent);
            }


            string condition = Console.ReadLine();
            int ageCondition = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Student, int, bool> tester = CreateTester(condition); // Namira si proverkata po koqto shte raboti
            studentsList = studentsList.Where(x => tester(x, ageCondition)).ToList(); // rabota po proverkata koqto si e namiril
            Action<Student> printer = FormatingPrinter(format); // Namira si proverkata po koqto shte raboti
            studentsList.ForEach(printer); // rabota po proverkata koqto si e namiril

        }

        static Action<Student> FormatingPrinter(string format)
        {
            switch (format)
            {
                case "name":
                    {
                        return x => Console.WriteLine(x.Name); //Stava ravno na "pritera"
                    }
                case "age":
                    {
                        return x => Console.WriteLine(x.Age); //Stava ravno na "pritera"

                    }
                case "name age":
                    {
                        return x => Console.WriteLine(x.Name + " - " + x.Age); //Stava ravno na "pritera"
                    }
                default:
                    return null;
            }
        }

        static Func<Student, int, bool> CreateTester(string condition)
        {
            switch (condition)
            {
                case "older":
                    {
                        return (s, age) => s.Age >= age; //Stava ravno na "pritera"
                    }
                case "younger":
                    {
                        return (s, age) => s.Age < age; //Stava ravno na "pritera"

                    }
                default:
                    return null;
            }
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
