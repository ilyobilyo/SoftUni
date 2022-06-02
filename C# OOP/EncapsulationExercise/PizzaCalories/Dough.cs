using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;
        private Dictionary<string, double> modifiers = new Dictionary<string, double>() 
        {
            { "white", 1.5 },
            { "wholegrain", 1.0 },
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 },
        };

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType.ToLower();
            BakingTechnique = bakingTechnique.ToLower();
            Weight = weight;
        }

        public string FlourType
        {
            get
            { 
                return flourType;
            }
            set 
            {
                if (value != "white" && value != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }


        public string BakingTechnique
        {
            get 
            { 
                return bakingTechnique;
            }
            set 
            {
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }

        public double CalculateDoughCalories()
        {
            double result = (2 * weight) * modifiers[flourType] * modifiers[bakingTechnique];

            return result;
        }
    }
}
