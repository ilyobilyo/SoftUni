﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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

        public int Endurance
        {
            get 
            { 
                return endurance;
            }
            set 
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }

                endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return sprint;
            }
            set
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException($"Sprint should be between 0 and 100.");
                }

                sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return dribble;
            }
            set
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException($"Dribble should be between 0 and 100.");
                }

                dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return passing;
            }
            set
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException($"Passing should be between 0 and 100.");
                }

                passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return shooting;
            }
            set
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException($"Shooting should be between 0 and 100.");
                }

                shooting = value;
            }
        }

        public int CalculateOverall()
        {
            double skillsSum = endurance + sprint + dribble + passing + shooting;
            int result = (int)Math.Round(skillsSum / 5.0);// Problem s Judge !!

            return result;
        }

        private bool IsStatValid(int stat)
        {
            return stat > 0 && stat < 100;
        }
    }
}
