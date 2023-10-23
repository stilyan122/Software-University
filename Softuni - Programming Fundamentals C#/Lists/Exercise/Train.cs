using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Train
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split();
            while (command[0]!="end")
            {
                if (command[0]=="Add")
                {
                    int passengers = int.Parse(command[1]);
                    wagons.Insert(wagons.Count, passengers);
                }
                else
                {
                    int passengers = int.Parse(command[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i]+passengers<=capacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ",wagons));
        }
    }
}
