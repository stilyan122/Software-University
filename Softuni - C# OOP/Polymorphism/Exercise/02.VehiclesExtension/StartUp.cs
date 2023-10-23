using System;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputCar = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(inputCar[1]),double.Parse(inputCar[2]),double.Parse(inputCar[3]));
            string[] inputTruck = Console.ReadLine().Split();
            Truck truck = new Truck(double.Parse(inputTruck[1]), double.Parse(inputTruck[2]),double.Parse(inputTruck[3]));
            string[] inputBus = Console.ReadLine().Split();
            Bus bus = new Bus(double.Parse(inputBus[1]), double.Parse(inputBus[2]), double.Parse(inputBus[3]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                switch (command[0])
                {
                    case "Drive":
                        if (command[1]=="Car")
                        {
                            car.Drive(double.Parse(command[2]));
                        }
                        else if (command[1]=="Truck")
                        {
                            truck.Drive(double.Parse(command[2]));
                        }
                        else if (command[1] == "Bus")
                        {
                            bus.Drive(double.Parse(command[2]));
                        }
                        break;
                    case "Refuel":
                        if (command[1] == "Car")
                        {
                            car.Refuel(double.Parse(command[2]));
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(command[2]));
                        }
                        else if (command[1] == "Bus")
                        {
                            bus.Refuel(double.Parse(command[2]));
                        }
                        break;
                    case "DriveEmpty":
                        bus.DriveEmpty(double.Parse(command[2]));
                        break;
                    default:
                        break;
                }
                if (command[0]=="End")
                {
                    break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
