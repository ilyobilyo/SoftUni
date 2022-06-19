using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double InitialFuelAvailable = 65;
        private const double InitialFuelConsumptionPerRace = 7.5;

        public TunedCar(string make, string model, string vIN, int horsePower)
            : base(make, model, vIN, horsePower, InitialFuelAvailable, InitialFuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            HorsePower -= (int)Math.Round(HorsePower * 0.03);
        }
    }
}
