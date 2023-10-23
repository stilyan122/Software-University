using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                int speed = int.Parse(input[1]);
                int power = int.Parse(input[2]);
                int weight = int.Parse(input[3]);
                string type = input[4];
                Car car = new Car(model, speed, power, weight, type);
                cars.Add(car);
            }
            string cargoType = Console.ReadLine();
            if (cargoType=="fragile")
            {
                cars = cars.Where(x => x.Cargo.Type == "fragile" && x.Cargo.Weight < 1000).ToList();
            }
            else if (cargoType=="flamable")
            {
                cars = cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList();
            }
            foreach  (var item in cars)
            {
                Console.WriteLine(item.Model);
            }
        }
    }
    public class Engine
    {
        private int speed;
        private int power;
        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }
        public int Speed { get; set; }
        public int Power { get; set; }
    }
    public class Cargo
    {
        private int weight;
        private string type;
        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }
        public int Weight { get; set; }
        public string Type { get; set; }
    }
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        public Car(string model, int speed, int power, int weight, string type)
        {
            this.Model = model;
            Engine engine = new Engine(speed, power);
            Cargo cargo = new Cargo(weight, type);
            this.Engine = engine;
            this.Cargo = cargo;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
    }
}
