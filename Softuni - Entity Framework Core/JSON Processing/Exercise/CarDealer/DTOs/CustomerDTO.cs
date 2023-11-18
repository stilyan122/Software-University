using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs
{
    public class CustomerDTO
    {
        public string fullName { get; set; }

        public int boughtCars { get; set; }

        public double spentMoney { get; set; }
    }
}
