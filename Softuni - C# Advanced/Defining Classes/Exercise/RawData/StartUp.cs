using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int speed = int.Parse(input[1]);
                int power = int.Parse(input[2]);
                int weight = int.Parse(input[3]);
                string type = input[4];
                double pressure1 = double.Parse(input[5]);
                int age1 = int.Parse(input[6]);
                double pressure2 = double.Parse(input[7]);
                int age2 = int.Parse(input[8]);
                double pressure3 = double.Parse(input[9]);
                int age3 = int.Parse(input[10]);
                double pressure4 = double.Parse(input[11]);
                int age4 = int.Parse(input[12]);
                Engine engine = new Engine(speed, power);
                List<Tire> tires = new List<Tire>();
                tires.Add(new Tire(age1, pressure1));
                tires.Add(new Tire(age2, pressure2));
                tires.Add(new Tire(age3, pressure3));
                tires.Add(new Tire(age4, pressure4));
                Cargo cargo = new Cargo(type, weight);
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            string cargoType = Console.ReadLine();
            if (cargoType =="fragile")
            {
                cars = cars
                    .Where(x => x.Cargo.Type == 
                "fragile" && 
                x.Tires.Find(t => t.Pressure < 1)!=default)
                    .ToList();
            }
            else if (cargoType=="flammable")
            {
                cars = cars
                    .Where(x => x.Cargo.Type ==
                "flammable" &&
                x.Engine.Power > 250).ToList();
            }
            foreach (Car car in cars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
