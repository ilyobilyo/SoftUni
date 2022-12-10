using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            if (egg.IsDone())
            {
                return;
            }

            var dye = bunny.Dyes.FirstOrDefault(x => x.IsFinished() == false);

            while (bunny.Energy > 0 && dye != null && !dye.IsFinished() && !egg.IsDone())
            {
                while (!egg.IsDone() && !dye.IsFinished())
                {
                    bunny.Work();
                    dye.Use();
                    egg.GetColored();
                }

                dye = bunny.Dyes.FirstOrDefault(x => x.IsFinished() == false);
            }
        }
    }
}
