using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class VehicleCatalogue
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split("/");
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            while (command[0]!="end")
            {
                string type = command[0];
                string brand = command[1];
                string model = command[2];
                if (type=="Car")
                {
                    double horsePower = double.Parse(command[3]);
                    Car car = new Car(brand, model, horsePower);
                    cars.Add(car);
                }
                else
                {
                    double weight = double.Parse(command[3]);
                    Truck truck = new Truck(brand, model, weight);
                    trucks.Add(truck);
                }
               command = Console.ReadLine().Split("/");
            }
            trucks = trucks.OrderBy(x => x.Brand).ToList();
            cars = cars.OrderBy(x => x.Brand).ToList();
            Catalogue catalogue = new Catalogue(trucks, cars);
            if (catalogue.Cars.Count>0)
            {
                Console.WriteLine("Cars:");
                foreach (var item in catalogue.Cars)
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.HorsePower}hp");
                }
            }
            if (catalogue.Trucks.Count>0)
            {
                Console.WriteLine("Trucks:");
                foreach (var item in catalogue.Trucks)
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
                }
            }
        }
    }
    public class Truck
    {
        private string brand;
        private string model;
        private double weight;
        public Truck(string brand,string model,double weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }
    public class Car
    {
        private string brand;
        private string model;
        private double horsePower;
        public Car(string brand, string model, double horsePower)
        {
            this.Brand = brand;
            this.Model = model;
            this.HorsePower = horsePower;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double HorsePower { get; set; }
    }
    public class Catalogue
    {
        private List<Truck> trucks;
        private List<Car> cars;
        public Catalogue(List<Truck> trucks,List<Car> cars)
        {
            this.Trucks = trucks;
            this.Cars = cars;
        }
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }
}
