using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] commands = Console.ReadLine().Split();
            while (commands[0]!="end")
            {
                if (commands[0]=="Delete")
                {
                    int element = int.Parse(commands[1]);
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i]==element)
                        {
                            nums.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    int element = int.Parse(commands[1]);
                    int index = int.Parse(commands[2]);
                    nums.Insert(index, element);
                }
                commands = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
