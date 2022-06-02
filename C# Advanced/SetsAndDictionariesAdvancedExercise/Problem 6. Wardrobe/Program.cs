using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                    for (int j = 0; j < clothes.Length; j++)
                    {
                        if (!wardrobe[color].ContainsKey(clothes[j]))
                        {
                            wardrobe[color].Add(clothes[j], 1);

                        }
                        else
                        {
                            wardrobe[color][clothes[j]]++;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < clothes.Length; j++)
                    {
                        if (!wardrobe[color].ContainsKey(clothes[j]))
                        {
                            wardrobe[color].Add(clothes[j], 1);

                        }
                        else
                        {
                            wardrobe[color][clothes[j]]++;
                        }
                    }
                }
            }

            string[] clothToFind = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string searchedColor = clothToFind[0];
            string searchedCloth = clothToFind[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    if (cloth.Key == searchedCloth && color.Key == searchedColor)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
