using System;
using System.Collections.Generic;
using WildFarm.Contracts;
using WildFarm.Factories;
using WildFarm.Models;
using WildFarm.Models.Animals;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animlas = new List<Animal>();

            while (true)
            {
                string[] animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (animalInfo[0] == "End")
                {
                    break;
                }

                string[] foodInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Animal animal = AnimalFactory.GetAnimalType(animalInfo);
                IFood food = FoodFactory.GetFoodType(foodInfo);

                Console.WriteLine(animal.ProducingSound());
                animal.Eat(food);
                animlas.Add(animal);
            }

            foreach (var animal in animlas)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
