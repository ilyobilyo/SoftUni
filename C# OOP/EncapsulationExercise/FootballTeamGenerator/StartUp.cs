using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "END")
                {
                    break;
                }

                if (command[0] == "Team")
                {
                    try
                    {
                        Team team = new Team(command[1]);

                        teams.Add(team.Name, team);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command[0] == "Add")
                {
                    try
                    {
                        string currentTeamName = command[1];

                        if (!teams.ContainsKey(currentTeamName))
                        {
                            Console.WriteLine($"Team {currentTeamName} does not exist.");
                            continue;
                        }

                        string playerName = command[2];
                        int endurance = int.Parse(command[3]);
                        int sprint = int.Parse(command[4]);
                        int dribble = int.Parse(command[5]);
                        int passing = int.Parse(command[6]);
                        int shooting = int.Parse(command[7]);


                        Player player = new Player(playerName, endurance, sprint,
                            dribble, passing, shooting);

                        teams[currentTeamName].AddPlayer(player);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                }
                else if (command[0] == "Remove")
                {
                    try
                    {
                        string currentTeamName = command[1];

                        teams[currentTeamName].RemovePlayer(command[2]);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command[0] == "Rating")
                {
                    string currentTeamName = command[1];

                    if (!teams.ContainsKey(currentTeamName))
                    {
                        Console.WriteLine($"Team {currentTeamName} does not exist.");
                        continue;
                    }

                    Console.WriteLine($"{currentTeamName} - {teams[currentTeamName].Rating}");
                }
            }
        }
    }
}
