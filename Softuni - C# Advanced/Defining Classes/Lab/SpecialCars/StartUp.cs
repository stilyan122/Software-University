using System;
using System.Collections.Generic;
namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        { 
            List<List<Tire>> tiresListSum = new List<List<Tire>>();
            List<Tire> tiresList = new List<Tire>();
            string[] command = Console.ReadLine().Split();
            while (command[0]!="No"&& command[1]!="more"&& command[2]!="tires")
            {
                if (command[0] == "No" && command[1] == "more" && command[2] == "tires")
                {
                    break;
                }
                else
                {
 
                    for (int i = 0; i < command.Length - 1; i++)
                    { 
                        int year = int.Parse(command[i]);
                        i++;
                        double pressure = double.Parse(command[i]);
                        Tire tire = new Tire(year, pressure);
                        tiresList.Add(tire);
                    }
                    tiresListSum.Add(tiresList);
                    tiresList = new List<Tire>();
                }
                command = Console.ReadLine().Split();
            }
            command = Console.ReadLine().Split();
            List<Engine> enginesList = new List<Engine>();
            while (command[0] != "Engines" && command[1] != "done")
            {
                if (command[0] == "Engines" && command[1] == "done")
                { 
                    break;
                }
                else
                {
                    int horsePower = int.Parse(command[0]);
                    double cubicCapacity = double.Parse(command[1]);
                    Engine engine = new Engine(horsePower, cubicCapacity);
                    enginesList.Add(engine);
                }
                
                command = Console.ReadLine().Split();
            }
            command = Console.ReadLine().Split();
            List<Car> carsList = new List<Car>();
            int h = 0;
            while (command[0] != "Show" && command[1] != "special")
            {
                if (command[0] == "Engines" && command[1] == "done")
                {
                    break;
                }
                else
                {

                   Tire tire = tiresListSum[h][int.Parse(command[6])];
                    h++;
                   Engine engine = enginesList[int.Parse(command[5])];
                   Car car = new Car(command[0],command[1],int.Parse(command[2]),double.Parse(command[3]),double.Parse(command[4]),engine,tire);
                    carsList.Add(car);
                }
                command = Console.ReadLine().Split();
            }
            for (int i = 0; i < carsList.Count; i++)
            {
                Car car = carsList[i];
                double sum = 0;
                for (int g = 0; g < tiresListSum[i].Count; g++)
                {
                    sum += tiresListSum[i][g].Pressure;
                }
                car.FuelQuantity = Quantity(car.FuelConsumption, car.FuelQuantity);
                if (car.Year>=2017&&car.Engine.HorsePower>330
                    &&sum>9&&sum<10)
                {
                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
            static double Quantity(double cons, double qu)
            {
                qu -= (cons / 100) * 20;
                return qu;
            }
        }
    }
}
