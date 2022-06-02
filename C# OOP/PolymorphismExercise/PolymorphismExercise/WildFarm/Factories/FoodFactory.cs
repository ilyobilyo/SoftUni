using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;
using WildFarm.Models;

namespace WildFarm.Factories
{
    public static class FoodFactory
    {
        public static IFood GetFoodType(string[] foodInfo)
        {
            IFood food = null;

            string foodType = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            if (foodType == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else if (foodType == "Vegetable")
            {
                food = new Vegetable(quantity);
            }

            return food;
        }
    }
}
