using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs
{
    public class CarDTO2
    {
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public long TraveledDistance { get; set; }
    }
}
