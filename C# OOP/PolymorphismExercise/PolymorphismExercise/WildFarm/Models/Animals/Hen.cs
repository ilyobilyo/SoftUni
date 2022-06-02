using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;
using WildFarm.Modifires;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            this.Weight += Modifires.Modifires.HenValue * food.Quantity;
            this.foodEaten += food.Quantity;
        }

        public override string ProducingSound()
        {
            return "Cluck";
        }
    }
}
