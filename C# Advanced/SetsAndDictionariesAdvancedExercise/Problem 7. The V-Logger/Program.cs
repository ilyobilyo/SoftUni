using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {

            var vloggerData = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            string followers = "followers"; //[] !!
            string following = "following"; //[] !!

            while (true)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "Statistics")
                {
                    break;
                }

                string vloggerName = command[0];
                string action = command[1];

                if (action == "joined")
                {
                    if (!vloggerData.ContainsKey(vloggerName))
                    {
                        vloggerData.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                        vloggerData[vloggerName].Add(followers, new SortedSet<string>()); //[] !!
                        vloggerData[vloggerName].Add(following, new SortedSet<string>()); //[] !!

                    }
                }
                else if (action == "followed")
                {
                    string userToFollow = command[2];
                    if (vloggerData.ContainsKey(vloggerName) && vloggerData.ContainsKey(userToFollow) && vloggerName != userToFollow)
                    {
                        vloggerData[vloggerName][following].Add(userToFollow); //[] !!
                        vloggerData[userToFollow][followers].Add(vloggerName); //[] !!
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggerData.Count} vloggers in its logs.");
            int count = 1;
            foreach (var vloger in vloggerData.OrderByDescending(x => x.Value[followers].Count).ThenBy(x => x.Value[following].Count)) //[] !!
            {
                Console.WriteLine($"{count}. {vloger.Key} : {vloger.Value[followers].Count} followers, {vloger.Value[following].Count} following"); //[] !!

                if (count == 1)
                {
                    foreach (var follwerName in vloger.Value[followers]) //[] !!
                    {
                        Console.WriteLine($"*  {follwerName}");
                    }
                }

                count++;
            }
        }
    }
}
