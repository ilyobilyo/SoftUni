using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.Weight += Modifires.Modifires.DogValue * food.Quantity;
                this.foodEaten += food.Quantity;
            }
            else
            {
                base.Eat(food);
            }
        }

        public override string ProducingSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
           return $"{base.ToString()} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
