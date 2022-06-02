using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string firstLine = Console.ReadLine();
                if (firstLine == "Beast!")
                {
                    break;
                }

                string[] animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);

                if (age <= 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (firstLine == "Cat")
                {
                    string gender = animalInfo[2];

                    Animal cat = new Cat(name, age, gender);
                    animals.Add(cat);
                }
                else if (firstLine == "Kitten")
                {
                    Animal kitten = new Kitten(name, age);
                    animals.Add(kitten);

                }
                else if (firstLine == "Tomcat")
                {
                    Animal tomcat = new Tomcat(name, age);
                    animals.Add(tomcat);

                }
                else if (firstLine == "Dog")
                {
                    string gender = animalInfo[2];

                    Animal dog = new Dog(name, age, gender);
                    animals.Add(dog);

                }
                else if (firstLine == "Frog")
                {
                    string gender = animalInfo[2];

                    Animal frog = new Frog(name, age, gender);
                    animals.Add(frog);

                }


            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
