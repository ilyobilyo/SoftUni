using System;
using System.Text;

namespace ExamPreparation2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var key = Console.ReadLine();

            var sb = new StringBuilder();


            while (true)
            {
                string[] command = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Generate")
                {
                    break;
                }

                if (command[0] == "Contains")
                {
                    var substring = command[1];

                    if (key.Contains(substring))
                    {
                        Console.WriteLine($"{key} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }

                }
                else if (command[0] == "Flip")
                {
                    var stratIndex = int.Parse(command[2]);
                    var endIndex = int.Parse(command[3]);

                    if (command[1] == "Upper")
                    {
                        var substring = key.Substring(stratIndex, endIndex - stratIndex);


                        key = key.Replace(substring, substring.ToUpper());

                    }
                    else
                    {
                        var substring = key.Substring(stratIndex, endIndex - stratIndex);

                        key = key.Replace(substring, substring.ToLower());
                    }

                    Console.WriteLine(key);
                }
                else if (command[0] == "Slice")
                {
                    var stratIndex = int.Parse(command[1]);
                    var endIndex = int.Parse(command[2]);

                    key = key.Remove(stratIndex, endIndex - stratIndex);

                    Console.WriteLine(key);
                }
            }

            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
