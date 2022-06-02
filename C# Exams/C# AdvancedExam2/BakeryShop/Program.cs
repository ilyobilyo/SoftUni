using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] inputWater = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] inputFlour = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Queue<double> water = new Queue<double>(inputWater);
            Stack<double> flour = new Stack<double>(inputFlour);
            Dictionary<string, int> productsBaked = new Dictionary<string, int>();

            while (water.Count > 0 && flour.Count > 0)
            {
                double currWater = water.Dequeue();
                double currFlour = flour.Pop();

                double sumOfWaterAndFlour = currWater + currFlour;
                double percentWater = (currWater * 100) / sumOfWaterAndFlour;

                if (percentWater == 40)
                {
                    if (!productsBaked.ContainsKey("Muffin"))
                    {
                        productsBaked.Add("Muffin", 0);
                    }

                    productsBaked["Muffin"]++;
                }
                else if (percentWater == 30)
                {
                    if (!productsBaked.ContainsKey("Baguette"))
                    {
                        productsBaked.Add("Baguette", 0);
                    }

                    productsBaked["Baguette"]++;
                }
                else if (percentWater == 20)
                {
                    if (!productsBaked.ContainsKey("Bagel"))
                    {
                        productsBaked.Add("Bagel", 0);
                    }

                    productsBaked["Bagel"]++;
                }
                else
                {
                    if (percentWater == 50)
                    {
                        if (!productsBaked.ContainsKey("Croissant"))
                        {
                            productsBaked.Add("Croissant", 0);
                        }

                        productsBaked["Croissant"]++;
                    }
                    else
                    {
                        if (!productsBaked.ContainsKey("Croissant"))
                        {
                            productsBaked.Add("Croissant", 0);
                        }

                        currFlour = currFlour - currWater;
                        productsBaked["Croissant"]++;
                        flour.Push(currFlour);
                    }
                }
            }

            foreach (var pair in productsBaked.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            if (water.Count > 0)
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flour.Count > 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
