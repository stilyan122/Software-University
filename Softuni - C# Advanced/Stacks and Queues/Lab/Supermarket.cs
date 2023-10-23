using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Supermarket
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Queue<string> arr = new Queue<string>();
            while (command != "end")
            {
                if (command == "End")
                {
                    break;
                }
                else if (command == "Paid")
                {
                    foreach (var item in arr)
                    {
                        Console.WriteLine(item);
                    }
                    arr.Clear();
                }
                else
                {
                    arr.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{arr.Count} people remaining.");
        }
    }
}
