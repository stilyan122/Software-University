using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public override double FuelConsumption { get; set; } = 8.0;
        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {

        }
    }
}
