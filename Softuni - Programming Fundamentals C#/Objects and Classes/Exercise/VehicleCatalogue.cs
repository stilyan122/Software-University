using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleCatalogue
{
    class VehicleCatalogue
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(" ");
            List<Vehicle> vehicles = new List<Vehicle>();
            while (command[0] != "End")
            {
                string type = command[0];
                string brand = command[1];
                string color = command[2];
                double horsePower = double.Parse(command[3]);
                Vehicle vehicle = new Vehicle(type, brand, color, horsePower);
                vehicles.Add(vehicle);  
                command = Console.ReadLine().Split(" ");
            }
            string brandStr = Console.ReadLine();
            while (brandStr!= "Close the Catalogue")
            {
                Console.WriteLine(vehicles.Where(x=>x.Brand==brandStr).ToList()[0].ToString());
                brandStr = Console.ReadLine();
            }
            List<Vehicle> cars = vehicles.Where(x => x.Type == "car").ToList();
            double av1 = 0.0;
            double av2 = 0.0;
            foreach (var car in cars)
            {
                av1 += car.HorsePower;
            }
            List<Vehicle> trucks = vehicles.Where(x => x.Type == "truck").ToList();
            foreach (var truck in trucks)
            {
                av2 += truck.HorsePower;
            }
            if (av1 > 0)
                av1 /= cars.Count;
            else
                av1 = 0;
            if (av2 > 0)
                av2 /= trucks.Count;
            else
                av2 = 0;
            Console.WriteLine($"Cars have average horsepower of: {av1:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {av2:f2}.");
        }
    }
    public class Vehicle
    {
        private string type;
        private string brand;
        private string color;
        private double horsePower;
        public Vehicle(string type,string brand, string color, double horsePower)
        {
            this.Type = type;
            this.Brand = brand;
            this.Color = color;
            this.HorsePower = horsePower;
        }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Type: {this.Type[0].ToString().ToUpper()+this.Type.Substring(1,this.Type.Length-1)}");
            output.AppendLine($"Model: {this.Brand}");
            output.AppendLine($"Color: {this.Color}");
            output.AppendLine($"Horsepower: {this.HorsePower}");
            return output.ToString().TrimEnd();
        }
    }
}
