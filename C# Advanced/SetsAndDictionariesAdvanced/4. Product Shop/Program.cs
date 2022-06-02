using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> ShopData = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Revision")
                {
                    break;
                }

                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!ShopData.ContainsKey(shop))
                {
                    ShopData.Add(shop, new Dictionary<string, double>());
                    ShopData[shop].Add(product, price);
                }
                else
                {
                    if (!ShopData[shop].ContainsKey(product))
                    {
                        ShopData[shop].Add(product, price);
                    }

                }
            }

            foreach (var shop in ShopData.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
