using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Car : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Car(double quantity,double consumption,double capacity)
        {
            this.TankCapacity = capacity;
            this.FuelQuantity = quantity;
            this.FuelConsumption = consumption;
        }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get;set;}
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


        public void Drive(double distance)
        {
            double take = FuelQuantity - (FuelConsumption + 0.9) * distance;
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
            if (fuel <= 0)
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
