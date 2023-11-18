using CarDealer.Models;

namespace CarDealer.DTOs
{
    public class CarPartDTO
    {
        public Car Car { get; set; }

        public int[] Parts { get; set; }
    }
}
