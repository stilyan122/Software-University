using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IBuyer> residents = new List<IBuyer>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length==4)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    residents.Add(citizen);
                    
                }
                else
                {
                    Rebel rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    residents.Add(rebel);
                }
            }
            int food = 0;
            List<string> names = new List<string>();
            string inputCommand = Console.ReadLine();
            while (inputCommand!="End")
            {
                names.Add(inputCommand);
                inputCommand = Console.ReadLine();
            }
            foreach (var name in names)
            {
                foreach (var resident in residents)
                {
                    if (name==resident.Name)
                    {
                        resident.BuyFood();
                    }
                }
            }
            foreach (var resident in residents)
            {
                food += resident.Food;
            }
            Console.WriteLine(food);
        }
    }
}
