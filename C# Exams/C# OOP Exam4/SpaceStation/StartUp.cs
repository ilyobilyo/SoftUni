namespace SpaceStation
{
    using Core;
    using Core.Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Planets;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Planet pl = new Planet("saturn");
            //Biologist bb = new Biologist("kasd");
            //Biologist aws = new Biologist("dd");
            //Biologist ds = new Biologist("as");
            //Biologist ww = new Biologist("ff");
            //ICollection<IAstronaut> asa = new List<IAstronaut>();
            //pl.Items.Add("asas");
            //pl.Items.Add("dd");
            //pl.Items.Add("d");
            //pl.Items.Add("tyu");
            //pl.Items.Add("wwwwww");

            //asa.Add(bb);
            //asa.Add(aws);
            //asa.Add(ds);
            //asa.Add(ww);

            //Mission mission = new Mission();
            //mission.Explore(pl, asa);

            //return;
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}