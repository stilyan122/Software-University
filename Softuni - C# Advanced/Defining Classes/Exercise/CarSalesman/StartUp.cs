using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            int n1 = int.Parse(Console.ReadLine());
            for (int i = 0; i < n1; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command.Length==2)
                {
                    Engine engine = new Engine(command[0], int.Parse(command[1]));
                    engines.Add(engine);
                }
                else
                {
                    Engine engine = new Engine(command[0], int.Parse(command[1]));
                    if (char.IsDigit(command[2][0]))
                    {
                        engine.Displacement = int.Parse(command[2]);
                        if (command.Length==4)
                        {
                            engine.Efficiency = command[3];
                        }
                    }
                    else
                    {
                        engine.Efficiency = command[2];
                    }
                    engines.Add(engine);
                }
            }
            int n2 = int.Parse(Console.ReadLine());
            for (int i = 0; i < n2; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command.Length == 2)
                {
                    Car car = new Car(command[0], engines.Find(x => x.Model == command[1]));
                    cars.Add(car);
                }
                else
                {
                    Car car = new Car(command[0], engines.Find(x => x.Model == command[1]));
                    if (char.IsDigit(command[2][0]))
                    {
                        car.Weight = int.Parse(command[2]);
                        if (command.Length == 4)
                        {
                            car.Color = command[3];
                        }
                    }
                    else
                    {
                        car.Color = command[2];
                    }
                    cars.Add(car);
                }
            }
            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
