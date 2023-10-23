using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Truck : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Truck(double quantity, double consumption,double capacity)
        {
            this.FuelConsumption = consumption;
            this.TankCapacity = capacity;
            this.FuelQuantity = quantity;
        }
        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public void Drive(double distance)
        {
            double take = FuelQuantity - (FuelConsumption + 1.6) * distance;
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
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (FuelQuantity + 0.95 * fuel <= TankCapacity)
                    FuelQuantity += 0.95 * fuel;
                else
                    Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
        }
    }
}
