using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class ParkingLot
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(", ");
            HashSet<string> cars = new HashSet<string>();
            while (carInfo[0] != "END")
            {
                if (carInfo[0] == "END")
                {
                    break;
                }
                else
                {
                    string command = carInfo[0];
                    string number = carInfo[1];
                    if (command == "IN")
                    {
                        cars.Add(number);
                    }
                    else if (command == "OUT")
                    {
                        cars.Remove(number);
                    }
                }
                carInfo = Console.ReadLine().Split(", ");
            }
            if (cars.Count > 0)
            {
                foreach (var item in cars)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
