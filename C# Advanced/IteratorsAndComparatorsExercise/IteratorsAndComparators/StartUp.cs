using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().Skip(1).ToList();

            ListyIterator<string> list = new ListyIterator<string>(input);

            try
            {
                while (true)
                {
                    string command = Console.ReadLine();
                    if (command == "END")
                    {
                        break;
                    }

                    if (command == "Move")
                    {
                        Console.WriteLine(list.Move());
                    }
                    else if (command =="HasNext")
                    {
                        Console.WriteLine(list.HasNext());
                    }
                    else if(command == "Print")
                    {
                        list.Print();
                    }
                    else if (command == "PrintAll")
                    {
                        foreach (var element in list)
                        {
                            Console.Write($"{element} ");
                        }

                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
