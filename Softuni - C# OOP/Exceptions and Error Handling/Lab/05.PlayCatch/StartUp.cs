using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayCatch
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split()
                  .Select(int.Parse).ToList();

            int exepCount = 0;

            while (exepCount < 3)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                try
                {
                    if (command == "Replace")
                    {
                        int index = int.Parse(input[1]);
                        nums[index] = int.Parse(input[2]);
                    }
                    else if (command == "Print")
                    {
                        int index = int.Parse(input[1]);
                        int endIndex = int.Parse(input[2]);
                        Console.WriteLine
                           (string.Join(", ", nums.GetRange(index, endIndex - index + 1)));
                    }
                    else if (command == "Show")
                    {
                        int index = int.Parse(input[1]);
                        Console.WriteLine(nums[index]);
                    }
                }
                catch
                {
                    if (input.Length > 2)
                    {
                        int check = 0;
                        if (int.TryParse(input[1], out check) &&
                            int.TryParse(input[2], out check))
                        {
                            Console.WriteLine("The index does not exist!");
                        }
                        else
                            Console.WriteLine("The variable is not in the correct format!");
                    }
                    else
                    {
                        int check = 0;
                        if (int.TryParse(input[1], out check))
                        {
                            Console.WriteLine("The index does not exist!");
                        }
                        else
                            Console.WriteLine("The variable is not in the correct format!");
                    }
                    exepCount++;
                }
            }
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
