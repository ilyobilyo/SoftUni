﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, 
            int openPositions,
            char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;

            Players = new List<Player>();
        }

        public List<Player> Players { get; set; }

        public string Name { get; set; }

        public int OpenPositions { get; set; }

        public char Group { get; set; }

        public int Count => Players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            Players.Add(player);

            OpenPositions--;

            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            var player = Players.FirstOrDefault(x => x.Name == name);

            if (player != null)
            {
                Players.Remove(player);

                OpenPositions++;

                return true;
            }
            else
            {
                return false;
            }
        }

        public int RemovePlayerByPosition(string position)
        {
            var playersToRemove = Players.Where(x => x.Position == position).ToList();

            if (playersToRemove.Count > 0)
            {
                Players.RemoveAll(x => x.Position == position);

                OpenPositions += playersToRemove.Count;

                return playersToRemove.Count;
            }
            else
            {
                return 0;
            }
        }

        public Player RetirePlayer(string name)
        {
            var player = Players.FirstOrDefault(x => x.Name == name);

            if (player != null)
            {
                player.Retired = true;

                return player;
            }
            else
            {
                return null;
            }
        }

        public List<Player> AwardPlayers(int games)
        {
            return Players.Where(x => x.Games >= games).ToList();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach (var player in Players.Where(x => x.Retired == false))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
