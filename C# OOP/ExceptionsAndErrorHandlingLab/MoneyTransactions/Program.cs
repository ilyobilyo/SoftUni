using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, double> accounts = new Dictionary<int, double>();

            AddAccountsToDictionary(input, accounts);

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "End")
                {
                    break;
                }

                try
                {
                    CommandExecution(command, accounts);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }

        static void AddAccountsToDictionary(string[] input, Dictionary<int, double> accounts)
        {
            foreach (var account in input)
            {
                string[] currAccInfo = account.Split("-", StringSplitOptions.RemoveEmptyEntries);

                int accNumber = int.Parse(currAccInfo[0]);
                double accSum = double.Parse(currAccInfo[1]);

                accounts.Add(accNumber, accSum);
            }
        }

        static void CommandExecution(string[] command, Dictionary<int, double> accounts)
        {
            int accNumber = int.Parse(command[1]);

            if (!accounts.ContainsKey(accNumber))
            {
                throw new ArgumentException("Invalid account!");
            }

            if (command[0] == "Deposit")
            {
                double accSum = double.Parse(command[2]);
                accounts[accNumber] += accSum;
            }
            else if (command[0] == "Withdraw")
            {
                double sumToWithdraw = double.Parse(command[2]);

                if (accounts[accNumber] < sumToWithdraw)
                {
                    throw new ArgumentException("Insufficient balance!");
                }
                else
                {
                    accounts[accNumber] -= sumToWithdraw;
                }
            }
            else
            {
                throw new ArgumentException("Invalid command!");
            }

            Console.WriteLine($"Account {accNumber} has new balance: {accounts[accNumber]:f2}");
        }
    }
}
