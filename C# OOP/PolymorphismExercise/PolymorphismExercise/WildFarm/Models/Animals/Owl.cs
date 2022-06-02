using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;
using WildFarm.Modifires;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.Weight += Modifires.Modifires.OwlValue * food.Quantity;
                this.foodEaten += food.Quantity;
            }
            else
            {
                base.Eat(food);
            }
        }

        public override string ProducingSound()
        {
            return $"Hoot Hoot";
        }
    }
}
