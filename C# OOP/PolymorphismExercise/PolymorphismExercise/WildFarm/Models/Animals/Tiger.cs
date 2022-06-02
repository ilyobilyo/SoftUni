using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.Weight += Modifires.Modifires.TigerValue * food.Quantity;
                this.foodEaten += food.Quantity;
            }
            else
            {
                base.Eat(food);
            }
        }

        public override string ProducingSound()
        {
            return "ROAR!!!";
        }
    }
}
