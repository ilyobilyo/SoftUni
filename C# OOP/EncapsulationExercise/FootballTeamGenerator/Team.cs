using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private Dictionary<string, Player> players;

        public Team(string name)
        {
            Name = name;

            players = new Dictionary<string, Player>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }
        public int Rating => CalculateRating();

        public void AddPlayer(Player player)
        {
            players.Add(player.Name, player);
        }

        public void RemovePlayer(string playerName)
        {
            if (players.ContainsKey(playerName))
            {
                players.Remove(playerName);
            }
            else
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }
            
        }

        private int CalculateRating()
        {
            double sum = 0;

            foreach (var player in players)
            {
                sum += player.Value.CalculateOverall();
            }

            if (players.Count == 0)
            {
                return 0;
            }

            return (int)(Math.Round(sum / players.Count));
        }
    }
}
