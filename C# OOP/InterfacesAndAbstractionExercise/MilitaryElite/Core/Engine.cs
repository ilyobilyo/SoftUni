using MilitaryElite.Contracts;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private Dictionary<string, ISoldier> repository = new Dictionary<string, ISoldier>();

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] personInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                AddSoldiersToRepository(personInfo);
            }

            PrintSoldiers();
        }

        private void AddSoldiersToRepository(string[] personInfo)
        {
            string id = personInfo[1];
            string firstName = personInfo[2];
            string lastName = personInfo[3];


            if (personInfo[0] == "Private")
            {
                decimal salary = decimal.Parse(personInfo[4]);

                ISoldier currentPrivate = new Private(id, firstName, lastName, salary);

                repository.Add(id, currentPrivate);
            }
            else if (personInfo[0] == "LieutenantGeneral")
            {
                decimal salary = decimal.Parse(personInfo[4]);

                ILieutenantGeneral lieutenant = new LieutenantGeneral(id, firstName, lastName, salary);

                for (int i = 5; i < personInfo.Length; i++)
                {
                    ISoldier soldier = repository[personInfo[i]];
                    lieutenant.AddISoldiers(soldier);
                }

                repository.Add(id, lieutenant);
            }
            else if (personInfo[0] == "Engineer")
            {
                decimal salary = decimal.Parse(personInfo[4]);
                string corp = personInfo[5];
                try
                {
                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corp);

                    for (int i = 6; i < personInfo.Length; i+=2)
                    {
                        IRepair repair = new Repair(personInfo[i], int.Parse(personInfo[i + 1]));
                        engineer.AddIRepair(repair);
                    }

                    repository.Add(id, engineer);
                }
                catch (Exception)
                {
                    
                }

            }
            else if (personInfo[0] == "Commando")
            {
                decimal salary = decimal.Parse(personInfo[4]);
                string corp = personInfo[5];

                try
                {
                    ICommando commando = new Commando(id, firstName, lastName, salary, corp);

                    for (int i = 6; i < personInfo.Length; i+=2)
                    {
                        if (personInfo[i+1] != "inProgress" && personInfo[i+1] != "Finished")
                        {
                            continue;
                        }

                        IMission mission = new Mission(personInfo[i], personInfo[i + 1]);
                        commando.AddIMission(mission);
                    }

                    repository.Add(id, commando);
                }
                catch (Exception)
                {
                    
                }
            }
            else if (personInfo[0] == "Spy")
            {
                int codeNumber = int.Parse(personInfo[4]);

                ISoldier spy = new Spy(id, firstName, lastName, codeNumber);
                repository.Add(id, spy);
            }
        }

        private void PrintSoldiers()
        {
            foreach (var soldier in repository)
            {
                Console.WriteLine(soldier.Value);
            }
        }
    }

}
