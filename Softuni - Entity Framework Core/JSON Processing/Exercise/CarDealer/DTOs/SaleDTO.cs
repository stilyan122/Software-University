using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs
{
    public class SaleDTO
    {
        public CarDTO2 car { get; set; }

        public string customerName { get; set; }

        public string discount { get; set; }

        public string price { get; set; }

        public string priceWithDiscount { get; set; }
    }
}
