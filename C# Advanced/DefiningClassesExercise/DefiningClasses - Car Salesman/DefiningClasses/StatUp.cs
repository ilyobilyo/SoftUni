using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StatUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 4)
                {
                    string model = input[0];
                    int power = int.Parse(input[1]);
                    int displacement = int.Parse(input[2]);
                    string efficiency = input[3];

                    Engine engine = new Engine(model, power, displacement, efficiency);
                    engines.Add(engine);
                }
                else if (input.Length == 3)
                {
                    bool isDisplacement = int.TryParse(input[2], out var disp);

                    if (isDisplacement)
                    {
                        string model = input[0];
                        int power = int.Parse(input[1]);

                        Engine engine = new Engine(model, power, disp);
                        engines.Add(engine);
                    }
                    else
                    {
                        string model = input[0];
                        int power = int.Parse(input[1]);
                        string efficiency = input[2];

                        Engine engine = new Engine(model, power, efficiency);
                        engines.Add(engine);
                    }
                }
                else
                {
                    string model = input[0];
                    int power = int.Parse(input[1]);
                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 4)
                {
                    string model = input[0];
                    Engine engine = engines.FirstOrDefault(x => x.Model == input[1]);
                    int wight = int.Parse(input[2]);
                    string color = input[3];

                    cars.Add(new Car(model, engine, wight, color));
                }
                else if (input.Length == 3)
                {
                    bool isWeight = int.TryParse(input[2], out var weight);

                    if (isWeight)
                    {
                        string model = input[0];
                        Engine engine = engines.FirstOrDefault(x => x.Model == input[1]);

                        cars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        string model = input[0];
                        Engine engine = engines.FirstOrDefault(x => x.Model == input[1]);
                        string color = input[2];

                        cars.Add(new Car(model, engine, color));
                    }
                }
                else
                {
                    string model = input[0];
                    Engine engine = engines.FirstOrDefault(x => x.Model == input[1]);

                    cars.Add(new Car(model, engine));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
