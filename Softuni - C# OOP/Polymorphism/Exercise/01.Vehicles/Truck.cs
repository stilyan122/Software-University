using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Truck(double quantity, double consumption)
        {
            this.FuelConsumption = consumption;
            this.FuelQuantity = quantity;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double take = (FuelQuantity - (FuelConsumption + 1.6) * distance);
            if (take>=0)
            {
                FuelQuantity-= ((FuelConsumption + 1.6) * distance);
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public void Refuel(double fuel)
        {
            FuelQuantity += (0.95 * fuel);
        }
    }
}
