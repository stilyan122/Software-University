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
        private Engine engine;
        private Tire[] tire;
        public Car()
        {

        }
        public Car(string make, string model, int year)
           : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make,string model,int year,double fuelQuantity,double fuelConsumption)
            :this(make,model,year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public Car(string make, string model, 
            int year, double fuelQuantity, 
            double fuelConsumption,Engine engine,
            Tire tire)
            :this(make,model,year,fuelQuantity,fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tire;
        }
        public string Make { get; set; } = "VW";
        public string Model { get; set; } = "Golf";
        public int Year { get; set; } = 2025;
        public double FuelQuantity { get; set; } = 200;
        public double FuelConsumption { get; set; } = 10;
        public Engine Engine { get; set;}
        public Tire Tires { get; set; }
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
