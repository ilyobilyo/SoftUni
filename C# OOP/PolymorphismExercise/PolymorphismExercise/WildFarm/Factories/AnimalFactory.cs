using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    public static class AnimalFactory
    {
        public static Animal GetAnimalType(string[] arguments)
        {
            Animal animal = null;

            string animalType = arguments[0];
            string animalName = arguments[1];
            double weight = double.Parse(arguments[2]);

            if (arguments.Length == 5)
            {
                string livigRegion = arguments[3];
                string breed = arguments[4];

                if (animalType == "Cat")
                {
                    animal = new Cat(animalName, weight, livigRegion, breed);
                }
                else if (animalType == "Tiger")
                {
                    animal = new Tiger(animalName, weight, livigRegion, breed);
                }
            }
            else
            {
                if (animalType == "Hen")
                {
                    double wingSize = double.Parse(arguments[3]);

                    animal = new Hen(animalName, weight, wingSize);
                }
                else if (animalType == "Owl")
                {
                    double wingSize = double.Parse(arguments[3]);

                    animal = new Owl(animalName, weight, wingSize);
                }
                else if (animalType == "Mouse")
                {
                    string livigRegion = arguments[3];

                    animal = new Mouse(animalName, weight, livigRegion);
                }
                else if (animalType == "Dog")
                {
                    string livigRegion = arguments[3];

                    animal = new Dog(animalName, weight, livigRegion);
                }
            }

            return animal;
        }
    }
}
