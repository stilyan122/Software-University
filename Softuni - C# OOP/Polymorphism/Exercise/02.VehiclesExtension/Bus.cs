using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Bus : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Bus(double quantity,double consumption,double capacity)
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
            double take = FuelQuantity - (FuelConsumption + 1.4) * distance;
            if (take >= 0)
            {
                FuelQuantity -= ((FuelConsumption + 1.4) * distance);
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
        public void DriveEmpty(double distance)
        {
            double take = FuelQuantity - FuelConsumption  * distance;
            if (take >= 0)
            {
                FuelQuantity -= FuelConsumption * distance;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void Refuel(double fuel)
        {
            if (fuel<=0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (FuelQuantity + fuel <= TankCapacity)
                    FuelQuantity += fuel;
                else
                    Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
        }
    }
}
