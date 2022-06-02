using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            var examParticipants = new SortedDictionary<string, int>();
            var examSubmissions = new Dictionary<string, int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split('-');
                if (input[0] == "exam finished")
                {
                    break;
                }

                if (input[1] == "banned")
                {
                    string bannedUser = input[0];

                    if (examParticipants.ContainsKey(bannedUser))
                    {
                        examParticipants.Remove(bannedUser);
                    }
                }
                else
                {
                    string username = input[0];
                    string language = input[1];
                    int points = int.Parse(input[2]);

                    if (!examParticipants.ContainsKey(username))
                    {
                        examParticipants.Add(username, points);
                    }
                    else
                    {
                        if (examParticipants[username] < points)
                        {
                            examParticipants[username] = points;
                        }
                    }

                    if (!examSubmissions.ContainsKey(language))
                    {
                        examSubmissions.Add(language, 1);
                    }
                    else
                    {
                        examSubmissions[language]++;
                    }
                }

            }

            Console.WriteLine("Results:");
            foreach (var user in examParticipants.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var language in examSubmissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
