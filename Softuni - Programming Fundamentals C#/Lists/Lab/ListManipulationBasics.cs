using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasics
{
    class ListManipulationBasics
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            while (command[0]!="end")
            {
                switch (command[0])
                {
                    case "Add":
                        int num1 = int.Parse(command[1]);
                        nums.Add(num1);
                        break;
                    case "Remove":
                        int num2 = int.Parse(command[1]);
                        nums.Remove(num2);
                        break;
                    case "RemoveAt":
                        int index1 = int.Parse(command[1]);
                        nums.RemoveAt(index1);
                        break;
                    case "Insert":
                        int num3 = int.Parse(command[1]);
                        int index2 = int.Parse(command[2]);
                        nums.Insert(index2, num3);
                        break;
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
