using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Barista_Contest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var coffeeQuantities = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var milkQuantities = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            var coffeeQueue = new Queue<int>(coffeeQuantities);
            var milkStack = new Stack<int>(milkQuantities);

            var drinks = new Dictionary<string, int>()
            {
                {"Cortado", 50 },
                {"Espresso", 75 },
                {"Capuccino", 100 },
                {"Americano", 150 },
                {"Latte", 200 },
            };

            var preparedDrinks = new Dictionary<string, int>()
            {
                {"Cortado", 0 },
                {"Espresso", 0 },
                {"Capuccino", 0 },
                {"Americano", 0 },
                {"Latte", 0 },
            };

            while (coffeeQueue.Count > 0 && milkStack.Count > 0)
            {
                var coffeeQuantity = coffeeQueue.Dequeue();
                var milkQuantity = milkStack.Pop();

                var sum = coffeeQuantity + milkQuantity;

                var key = drinks.FirstOrDefault(x => x.Value == sum).Key;

                if (key != null)
                {
                    preparedDrinks[key]++;
                }
                else
                {
                    milkQuantity -= 5;
                    milkStack.Push(milkQuantity);
                }
            }

            if (coffeeQueue.Count == 0 && milkStack.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffeeQueue.Count > 0)
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffeeQueue)}");
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }

            if (milkStack.Count > 0)
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milkStack)}");
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }

            foreach (var drink in preparedDrinks.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                if (drink.Value > 0)
                {
                    Console.WriteLine($"{drink.Key}: {drink.Value}");
                }
            }
        }
    }
}
