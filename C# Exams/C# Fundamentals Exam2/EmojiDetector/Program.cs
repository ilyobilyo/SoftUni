using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = @":{2}[A-Z][a-z]{2,}:{2}|\*{2}[A-Z][a-z]{2,}\*{2}";

            Regex regex = new Regex(pattern);

            var input = Console.ReadLine();

            var coolThreshold = 1;

            foreach (var character in input)
            {
                if (char.IsDigit(character))
                {
                    coolThreshold *= int.Parse(character.ToString());
                }
            }

            var matchCollection = Regex.Matches(input, pattern);

            var emojisToPrint = new List<Match>();

            foreach (Match match in matchCollection)
            {
                var currentSum = 0;

                var matchAsString = match.ToString();

                for (int i = 0; i < matchAsString.Length; i++)
                {
                    if (char.IsLetter(matchAsString[i]))
                    {
                        currentSum += matchAsString[i];
                    }
                }

                if (currentSum > coolThreshold)
                {
                    emojisToPrint.Add(match);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{matchCollection.Count} emojis found in the text. The cool ones are:");

            foreach (var emoji in emojisToPrint)
            {
                Console.WriteLine(emoji.ToString());
            }
        }
    }
}
