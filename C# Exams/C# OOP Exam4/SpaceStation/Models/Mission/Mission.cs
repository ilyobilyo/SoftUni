using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> planetItams = planet.Items.ToList();

            foreach (var astronaut in astronauts.Where(x => x.CanBreath))
            {
                while(planetItams.Count > 0)
                {
                    string item = planetItams[0];
                    astronaut.Bag.Items.Add(item);
                    planetItams.Remove(item);
                    planet.Items.Remove(item);
                    astronaut.Breath();
                    if (!astronaut.CanBreath)
                    {
                        break;
                    }
                }
            }
        }
    }
}
