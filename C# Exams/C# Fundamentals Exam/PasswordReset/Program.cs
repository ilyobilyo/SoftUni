using System;
using System.Text;

namespace PasswordReset
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var sb = new StringBuilder();

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Done")
                {
                    break;
                }

                if (command[0] == "TakeOdd")
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            sb.Append(input[i]);
                        }

                    }

                    input = sb.ToString();

                }
                else if (command[0] == "Cut")
                {
                    int index = int.Parse(command[1]);
                    int length = int.Parse(command[2]);

                    input = input.Remove(index, length);
                }
                else if (command[0] == "Substitute")
                {
                    string substring = command[1];
                    string substitute = command[2];

                    if (!input.Contains(substring))
                    {
                        Console.WriteLine("Nothing to replace!");
                        continue;
                    }

                    input = input.Replace(substring, substitute);
                }

                Console.WriteLine(input);

            }

            Console.WriteLine($"Your password is: {input}");
        }
    }
}
