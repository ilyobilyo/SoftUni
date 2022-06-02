using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var userData = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(':');
                if (input[0] == "end of contests")
                {
                    break;
                }

                string currContest = input[0];
                string password = input[1];

                if (!contests.ContainsKey(currContest))
                {
                    contests.Add(currContest, password);
                }


            }

            while (true)
            {
                string[] input = Console.ReadLine().Split("=>");
                if (input[0] == "end of submissions")
                {
                    break;
                }

                string currContest = input[0];
                string password = input[1];
                string username = input[2];
                int points = int.Parse(input[3]);

                if (!contests.ContainsKey(currContest) || contests[currContest] != password)
                {
                    continue;
                }

                if (!userData.ContainsKey(username))
                {
                    userData.Add(username, new Dictionary<string, int>());
                    userData[username].Add(currContest, points);
                }
                else
                {
                    if (!userData[username].ContainsKey(currContest))
                    {
                        userData[username].Add(currContest, points);
                    }
                    else
                    {
                        if (userData[username][currContest] < points)
                        {
                            userData[username][currContest] = points;
                        }
                    }
                }
            }


            string bestUser = "";
            int sum = 0;
            foreach (var user in userData)
            {
                int currSum = 0;
                foreach (var pair in userData[user.Key])
                {
                    currSum += pair.Value;
                }

                if (currSum > sum)
                {
                    bestUser = user.Key;
                    sum = currSum;
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {sum} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in userData.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}");
                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
