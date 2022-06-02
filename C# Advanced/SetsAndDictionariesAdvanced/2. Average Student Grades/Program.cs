using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //Izpolzvam decimal za po tochni smetki i pri printiraneto ocenkite da sa s dva znaka sled zapetaqta!!
            Dictionary<string, List<decimal>> studentData = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(' ');
                string name = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);


                if (!studentData.ContainsKey(name))
                {
                    studentData.Add(name, new List<decimal>());
                    studentData[name].Add(grade);
                }
                else
                {
                    studentData[name].Add(grade);
                }
            }

            foreach (var pair in studentData)
            {
                Console.WriteLine($"{pair.Key} -> {string.Join(" ", pair.Value.Select(grade => grade.ToString("f2")))} (avg: {pair.Value.Average():f2})");
            }
        }
    }
}
