using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class SpeedRacing
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double amount = double.Parse(input[1]);
                double consumption = double.Parse(input[2]);
                Car car = new Car(model, amount, consumption, 0.0);
                cars.Add(car);
            }
            string[] command = Console.ReadLine().Split();
            while (command[0]!="End")
            {
                string model = command[1];
                double km = double.Parse(command[2]);
                Car car = cars.Where(x => x.Model == model).ToList()[0];
                car.CanDrive(km);
                command = Console.ReadLine().Split();
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Model} {item.Amount:f2} {item.Travelled}");
            }
        }
    }
    public class Car
    {
        private string model;
        private double amount;
        private double consumption;
        private double travelled;
        public Car(string model, double amount, double consumption, double travelled)
        {
            this.Model = model;
            this.Amount = amount;
            this.Consumption = consumption;
            this.Travelled = travelled;
        }
        public string Model { get; set; }
        public double Amount { get; set; }
        public double Consumption { get; set; }
        public double Travelled { get; set; }
        public void CanDrive(double distance)
        {
            if (this.Amount-distance*this.Consumption>=0)
            {
                this.Amount -= distance * this.Consumption;
                this.Travelled += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
