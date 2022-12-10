using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private IRepository<IBunny> bunnies;
        private IRepository<IEgg> eggs;

        public Controller()
        {
            this.bunnies= new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            switch (bunnyType)
            {
                case "HappyBunny":
                    {
                        bunny = new HappyBunny(bunnyName);
                        break;
                    }
                case "SleepyBunny":
                    {
                        bunny = new SleepyBunny(bunnyName);
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
                    }
            }

            bunnies.Add(bunny);

            return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            if (!bunnies.Models.Any(x => x.Name == bunnyName))
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            var bunny = bunnies.FindByName(bunnyName);
            var dye = new Dye(power);

            bunny.AddDye(dye);

            return String.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var egg = new Egg(eggName, energyRequired);

            eggs.Add(egg);

            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            if (bunnies.Models.Count == 0 || bunnies.Models.Count(x => x.Energy >= 50) == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            var worshop = new Workshop();

            var egg = eggs.FindByName(eggName);

            foreach (var bunny in bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy))
            {
                worshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }

                if (egg.IsDone())
                {
                    break;
                }
            }

            if (egg.IsDone())
            {
                return String.Format(OutputMessages.EggIsDone, eggName);
            }
            else
            {
                return String.Format(OutputMessages.EggIsNotDone, eggName);
            }
        }

        public string Report()
        {
            var sb = new StringBuilder();

            var coloredEggsCount = eggs.Models.Count(x => x.IsDone());

            sb.AppendLine($"{coloredEggsCount} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                var dyesCount = bunny.Dyes.Count(x => x.IsFinished() == false);

                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {dyesCount} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
