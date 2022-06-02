using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] allPeople = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            string[] allProducts = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Person> peopleDict = new Dictionary<string, Person>();
            Dictionary<string, Product> productDict = new Dictionary<string, Product>();


            try
            {
                for (int i = 0; i < allPeople.Length; i += 2)
                {
                    Person currPerson = new Person(allPeople[i], decimal.Parse(allPeople[i + 1]));

                    peopleDict.Add(allPeople[i], currPerson);
                }

                for (int i = 0; i < allProducts.Length; i += 2)
                {
                    Product currProduct = new Product(allProducts[i], decimal.Parse(allProducts[i + 1]));

                    productDict.Add(allProducts[i], currProduct);
                }

                while (true)
                {
                    string[] purchase = Console.ReadLine().Split();
                    if (purchase[0] == "END")
                    {
                        break;
                    }

                    string personName = purchase[0];
                    string productName = purchase[1];

                    Person currPerson = peopleDict[personName];
                    Product currProduct = productDict[productName];

                    if (!currPerson.AddProduct(currProduct))
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }

                }

                foreach (var item in peopleDict)
                {
                    Console.WriteLine(item.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
