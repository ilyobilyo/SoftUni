using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Models
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandIterpreter)
        {
            this.commandInterpreter = commandIterpreter;
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    string result = commandInterpreter.Read(input);

                    Console.WriteLine(result);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
