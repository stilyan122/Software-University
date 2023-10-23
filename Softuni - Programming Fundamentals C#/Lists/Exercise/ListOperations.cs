using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class ListOperations
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            while (command[0]!="End")
            {
                switch (command[0])
                {
                    case "Add":
                        int element1 = int.Parse(command[1]);
                        nums.Add(element1);
                        break;
                    case "Insert":
                        int element2 = int.Parse(command[1]);
                        int index1 = int.Parse(command[2]);
                        if (index1 < 0 || index1 >= nums.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            nums.Insert(index1, element2);
                        }
                        break;
                    case "Remove":
                        int index2 = int.Parse(command[1]);
                        if (index2 < 0 || index2 >= nums.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            nums.RemoveAt(index2);
                        }
                        break;
                    case "Shift":
                        if (command[1]=="left")
                        {
                            int count = int.Parse(command[2]);
                            for (int i = 0; i < count; i++)
                            {
                                int numToRemove = nums[0];
                                nums.RemoveAt(0);
                                nums.Add(numToRemove);
                            }
                        }
                        else
                        {
                            int count = int.Parse(command[2]);
                            for (int i = 0; i < count; i++)
                            {
                                int numToRemove = nums[nums.Count-1];
                                nums.RemoveAt(nums.Count-1);
                                nums.Insert(0, numToRemove);
                            }
                        }
                        break;
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
