using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Fruit)
            {
                this.Weight += Modifires.Modifires.MouseValue * food.Quantity;
                this.foodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProducingSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{base.ToString()} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
