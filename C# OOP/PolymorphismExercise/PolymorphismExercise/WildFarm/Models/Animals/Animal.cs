using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected int foodEaten = 0;
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public int FoodEaten => foodEaten;

        public abstract string ProducingSound();

        public virtual void Eat(IFood food)
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        public override string ToString()
        {
            return $"{GetType().Name}";
        }
    }
}
