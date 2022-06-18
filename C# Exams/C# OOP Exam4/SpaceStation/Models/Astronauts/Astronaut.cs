using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            Bag = new Backpack();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                name = value;
            }
        }

        public double Oxygen
        {
            get
            {
                return oxygen;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                oxygen = value;
            }
        }

        public bool CanBreath 
        {
            get
            {
                if (Oxygen <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            } 
        }

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            Oxygen -= 10;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Oxygen: {Oxygen}");

            string bagItems;
            if (Bag.Items.Count == 0)
            {
                bagItems = "none";
            }
            else
            {
                bagItems = string.Join(", ", Bag.Items);
            }
            sb.AppendLine($"Bag items: {bagItems}");

            return sb.ToString().TrimEnd();
        }
    }
}
