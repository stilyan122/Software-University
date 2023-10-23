using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        
        public string Make { 
            get {
                return this.make;
            }
            set
            {
                this.make = value;
            } 
        }
        public string Model {
            get {
                return this.model;  
            }
            set
            {
                this.model = value;
            }
        }
        public int Year { get
            {
             return this.year;
            }
            set
            {
                this.year = value;
            }
        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                this.fuelQuantity = value;
            }
        }
        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set
            {
                this.fuelConsumption = value;
            }
        }
        public void Drive(double distance)
        {
            if (fuelQuantity-(distance * fuelConsumption) > 0)
            {
                fuelQuantity -= (distance * fuelConsumption);
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            StringBuilder car = new StringBuilder();
            car.Append($"Make: {this.Make}");
            car.Append(Environment.NewLine);
            car.Append($"Model: {this.Model}");
            car.Append(Environment.NewLine);
            car.Append($"Year: {this.Year}");
            car.Append(Environment.NewLine);
            car.Append($"Fuel: {this.FuelQuantity:F2}");
            return car.ToString();
        }
    }
}
