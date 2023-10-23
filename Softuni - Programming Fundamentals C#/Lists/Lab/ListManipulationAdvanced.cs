using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationAdvanced
{
    class ListManipulationAdvanced
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            bool hasChanged = false;
            while (command[0]!="end")
            {
                switch (command[0])
                {
                    case "Add":
                        hasChanged = true;
                        int num1 = int.Parse(command[1]);
                        nums.Add(num1);
                        break;
                    case "Remove":
                        hasChanged = true;
                        int num2 = int.Parse(command[1]);
                        nums.Remove(num2);
                        break;
                    case "RemoveAt":
                        hasChanged = true;
                        int index1 = int.Parse(command[1]);
                        nums.RemoveAt(index1);
                        break;
                    case "Insert":
                        hasChanged = true;
                        int num3 = int.Parse(command[1]);
                        int index2 = int.Parse(command[2]);
                        nums.Insert(index2, num3);
                        break;
                    case "Contains":
                        int num4 = int.Parse(command[1]);
                        if (nums.Contains(num4))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ",nums.Where(x=>x%2==0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", nums.Where(x => x % 2 == 1)));
                        break;
                    case "GetSum":
                        Console.WriteLine(nums.Sum());
                        break;
                    case "Filter":
                        string symbol = command[1];
                        int number = int.Parse(command[2]);
                        switch (symbol)
                        {
                            case ">":
                                Console.WriteLine(string.Join(" ", nums.Where(x => x > number).ToList()));
                                break;
                            case ">=":
                                Console.WriteLine(string.Join(" ",nums.Where(x => x >= number).ToList()));
                                break;
                            case "<":
                                Console.WriteLine(string.Join(" ", nums.Where(x => x < number).ToList()));
                                break;
                            case "<=":
                                Console.WriteLine(string.Join(" ", nums.Where(x => x <= number).ToList()));
                                break;
                        }
                        break;
                }
                command = Console.ReadLine().Split();
            }
            if (hasChanged)
            {
                Console.WriteLine(string.Join(" ",nums));
            }
        }
    }
}
