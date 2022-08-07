using System;
using System.Text;

namespace Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Abracadabra")
                {
                    break;
                }

                if (command[0] == "Abjuration")
                {
                    input = input.ToUpper();

                    Console.WriteLine(input);
                }
                else if (command[0] == "Necromancy")
                {
                    input = input.ToLower();

                    Console.WriteLine(input);
                }
                else if (command[0] == "Illusion")
                {
                    var sb = new StringBuilder();

                    sb.Append(input);

                    int index = int.Parse(command[1]);

                    if (index < 0 || index > input.Length - 1)
                    {
                        Console.WriteLine("The spell was too weak.");

                        continue;
                    }

                    var letter = char.Parse(command[2]);

                    sb[index] = letter;

                    input = sb.ToString();

                   // input = input.Replace(input[index], letter);

                    Console.WriteLine("Done!");

                }
                else if (command[0] == "Divination")
                {
                    var firstSubstring = command[1];

                    if (!input.Contains(firstSubstring))
                    {
                        continue;
                    }

                    var secondSubstring = command[2];

                    input = input.Replace(firstSubstring, secondSubstring);

                    Console.WriteLine(input);
                }
                else if (command[0] == "Alteration")
                {
                    var substring = command[1];

                    if (!input.Contains(substring))
                    {
                        continue;
                    }

                    int startIndex = input.IndexOf(substring);

                    input = input.Remove(startIndex, substring.Length);

                    Console.WriteLine(input);
                }
                else
                {
                    Console.WriteLine("The spell did not work!");
                }
            }
        }
    }
}
