using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> data = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!data.ContainsKey(continent))
                {
                    data.Add(continent, new Dictionary<string, List<string>>());
                    data[continent].Add(country, new List<string>());
                    data[continent][country].Add(city);
                }
                else
                {
                    if (!data[continent].ContainsKey(country))
                    {
                        data[continent].Add(country, new List<string>());
                        data[continent][country].Add(city);
                    }
                    else
                    {
                        data[continent][country].Add(city);
                    }
                }
            }

            foreach (var continet in data)
            {
                Console.WriteLine($"{continet.Key}:");
                foreach (var country in continet.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
