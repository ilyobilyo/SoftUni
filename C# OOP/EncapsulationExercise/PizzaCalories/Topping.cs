using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private int weight;
        private Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 },
        };

        public Topping(string toppingType, int weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        public string ToppingType
        {
            get 
            { 
                return toppingType;
            }
            set 
            {
                string valueToLower = value.ToLower();
                if (valueToLower != "meat" && valueToLower != "veggies"
                    && valueToLower != "cheese" && valueToLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value;
            }
        }


        public int Weight
        {
            get 
            { 
                return weight;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");
                }
                weight = value; 
            }
        }

        public double CalculateToppingCalories()
        {
            double result = (2 * weight) * modifiers[toppingType.ToLower()];

            return result;
        }

    }
}
