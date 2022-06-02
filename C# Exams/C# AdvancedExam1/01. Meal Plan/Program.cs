using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    class Program
    {
        static void Main(string[] args)
        {
            int saladCalories = 350;
            int soupCalories = 490;
            int pastaCalories = 680;
            int steakCalories = 790;
            int countMeals = 0;
            int diff = 0;

            string[] inputMeals = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] inputCalories = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<string> meals = new Queue<string>(inputMeals);
            Stack<int> dailyCalories = new Stack<int>(inputCalories);

            while (meals.Count > 0 && dailyCalories.Count > 0)
            {
                int currCalories = dailyCalories.Pop();
                string currMeal = meals.Peek();

                if (currMeal == "salad")
                {
                    currCalories -= saladCalories;
                }                                
                else if (currMeal == "soup")     
                {                                
                    currCalories -= soupCalories ;
                }                                
                else if (currMeal == "pasta")    
                {                                
                    currCalories -= pastaCalories;
                }                                
                else                             
                {                                
                    currCalories -= steakCalories;
                }

                if (currCalories == 0)
                {
                    dailyCalories.Pop();
                    currCalories = dailyCalories.Peek();
                    continue;
                }

                if (currCalories < 0)
                {
                    if (dailyCalories.Count > 0)
                    {
                        diff = Math.Abs(currCalories);
                        currCalories = dailyCalories.Pop() - diff;
                    }
                    else
                    {
                        // Problema beshe tazi cqlata proverka !!!
                        meals.Dequeue();
                        countMeals++;
                        break;
                    }
                }

                dailyCalories.Push(currCalories);
                meals.Dequeue();
                countMeals++;
            }

            if (dailyCalories.Count > 0)
            {
                Console.WriteLine($"John had {countMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", dailyCalories)} calories.");
            }

            if (meals.Count > 0)
            {
                Console.WriteLine($"John ate enough, he had {countMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
