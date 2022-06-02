using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Tournament")
                {
                    break;
                }

                string trainerName = input[0];
                string pokemonName = input[1];
                string element = input[2];
                double health = double.Parse(input[3]);

                Trainer trainer = new Trainer(trainerName);
                Pokemon pokemon = new Pokemon(pokemonName, element, health);
                trainer.Pokemons.Add(pokemon);
                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, trainer);
                }
                else
                {
                    trainers[trainerName].Pokemons.Add(pokemon);
                }

            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                if (command == "Fire")
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Value.Pokemons.Any(x => x.Element == "Fire"))
                        {
                            trainer.Value.Badges++;
                        }
                        else
                        {
                            trainer.Value.Pokemons.ForEach(x => x.Health -= 10); // !!! Ne hvurlq Exeption
                            trainer.Value.Pokemons.RemoveAll(x => x.Health <= 0); // !!! Ne hvurlq Exeption
                        }
                    }
                }
                else if (command == "Water")
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Value.Pokemons.Any(x => x.Element == "Water"))
                        {
                            trainer.Value.Badges++;
                        }
                        else
                        {
                            trainer.Value.Pokemons.ForEach(x => x.Health -= 10); // !!! Ne hvurlq Exeption
                            trainer.Value.Pokemons.RemoveAll(x => x.Health <= 0); // !!! Ne hvurlq Exeption
                        }
                    }
                }
                else if (command == "Electricity")
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Value.Pokemons.Any(x => x.Element == "Electricity"))
                        {
                            trainer.Value.Badges++;
                        }
                        else
                        {
                            trainer.Value.Pokemons.ForEach(x => x.Health -= 10); // !!! Ne hvurlq Exeption !! Tozi pohod purvo namalq vsichki pokemoni s 10, a s normalniq foreach maha 10 heath i vednaga maha dadeniq pokemon koeto vodi do greshka 
                            trainer.Value.Pokemons.RemoveAll(x => x.Health <= 0); // !!! Ne hvurlq Exeption !! I sled tova maha vsichki koito sa pod 0 health
                        }
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine($"{trainer.Value.Name} {trainer.Value.Badges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
