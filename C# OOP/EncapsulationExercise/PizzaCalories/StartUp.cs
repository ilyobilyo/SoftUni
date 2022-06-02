using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                List<Dough> doughs = new List<Dough>();
                List<Topping> toppings = new List<Topping>();

                string[] pizzaInfo = Console.ReadLine().Split();
                Pizza pizza = new Pizza(pizzaInfo[1]);

                string[] doughInfo = Console.ReadLine().Split();
                Dough dough = new Dough(doughInfo[1], doughInfo[2], int.Parse(doughInfo[3]));
                pizza.Dough = dough;

                while (true)
                {
                    string[] input = Console.ReadLine().Split();
                    if (input[0] == "END")
                    {
                        break;
                    }

                    Topping topping = new Topping(input[1], int.Parse(input[2]));
                    pizza.AddTopping(topping);

                }


                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
                //foreach (var dough in doughs)
                //{
                //    Console.WriteLine($"{dough.CalculateDoughCalories():f2}");
                //}

                //foreach (var topping in toppings)
                //{
                //    Console.WriteLine($"{topping.CalculateToppingCalories():f2}");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
