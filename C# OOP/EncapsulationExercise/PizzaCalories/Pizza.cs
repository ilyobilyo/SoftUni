using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough { get; set; }
        public List<Topping> Toppings => toppings;
        public double TotalCalories
        {
            get
            {
                return CalculateTotalCalories();
            }
        }

        public void AddTopping(Topping toping)
        {
            if (!CheckingForToppingsCountIsValid())
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(toping);
        }


        private bool CheckingForToppingsCountIsValid()
        {
            if (toppings.Count > 10)
            {
                return false;
            }

            return true;
        }

        private double CalculateTotalCalories()
        {
            double toppingSum = 0;
            foreach (var topping in toppings)
            {
                toppingSum += topping.CalculateToppingCalories();

            }

            double doughSum = Dough.CalculateDoughCalories();

            return doughSum + toppingSum;
        }

    }
}
