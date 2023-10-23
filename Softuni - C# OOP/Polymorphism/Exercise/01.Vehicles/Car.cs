using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Car(double quantity,double consumption)
        {
            this.FuelConsumption = consumption;
            this.FuelQuantity = quantity;
        }
        public double FuelQuantity { get ; set; }
        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double take = (FuelQuantity - (FuelConsumption + 0.9) * distance);
            if (take >= 0)
            {
                FuelQuantity -= ((FuelConsumption + 0.9) * distance);
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            { 
                Console.WriteLine("Car needs refueling");
            }
        }
        
        public void Refuel(double fuel)
        {
            FuelQuantity += fuel;   
        }
    }
}
