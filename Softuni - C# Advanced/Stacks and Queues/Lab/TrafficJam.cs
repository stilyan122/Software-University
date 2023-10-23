using System;
using System.Text;
using System.Collections.Generic;

namespace TrafficJam
{
    class TrafficJam
    {
        static void Main(string[] args)
        {
            int passNumber = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split(" ");
            Queue<string> arr = new Queue<string>();
            int count = 0;
            while (command[0] != "end")
            {
                if (command[0] == "end")
                {
                    break;
                }
                else if (command[0] == "green")
                {
                    for (int i = 0; i < passNumber; i++)
                    {
                        if (arr.Count <= 0)
                        {
                            break;
                        }
                        else
                        {
                            count++;
                            Console.WriteLine($"{arr.Dequeue()} passed!");
                        }
                    }
                }
                else
                {
                    StringBuilder car = new StringBuilder();
                    if (command.Length > 1)
                    {
                        int count1 = command.Length;
                        foreach (var item in command)
                        {
                            if (count1 > 1)
                            {
                                car.Append(item + " ");
                            }
                            else if (count1 == 1)
                            {
                                car.Append(item);
                            }
                            count1--;
                        }
                    }
                    else
                    {
                        foreach (var item in command)
                        {
                            car.Append(item);
                        }
                    }
                    arr.Enqueue(car.ToString());
                }
                command = Console.ReadLine().Split(" ");
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
