using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MessageTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"!(?<command>[A-Z]{1}[a-z]{2,})!:\[(?<string>[A-Za-z]{8,})\]";

            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                if (!regex.IsMatch(input))
                {
                    Console.WriteLine("The message is invalid");

                    continue;
                }

                var match = regex.Match(input);

                var command = match.Groups["command"].Value;

                var text = match.Groups["string"].Value;

                List<int> chars = new List<int>();

                for (int j = 0; j < text.Length; j++)
                {
                    chars.Add(text[j]);
                }

                Console.WriteLine($"{command}: {string.Join(" ", chars)}");
            }
        }
    }
}
