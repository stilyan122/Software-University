using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    class SoftUniParking
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> parking = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = command[0];
                string name = command[1];
                if (type=="register")
                {
                    string plate = command[2];
                    if (parking.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plate}");
                    }
                    else
                    {
                        parking.Add(name, plate);
                        Console.WriteLine($"{name} registered {plate} successfully");
                    }
                }
                else if (type=="unregister")
                {
                    if (!parking.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        parking.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }
            }
            foreach (var car in parking)
            {
                Console.WriteLine(car.Key+" => "+car.Value);
            }
        }
    }
}
