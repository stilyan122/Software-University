using System;
using System.Collections.Generic;

namespace HotPotato
{
    class HotPotato
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ");
            int n = int.Parse(Console.ReadLine());
            Queue<string> arr = new Queue<string>();
            int a = 1;
            for (int i = 0; i < names.Length; i++)
            {
                arr.Enqueue(names[i]);
            }
            while (arr.Count > 1)
            {
                for (int i = a; i <= n; i++)
                {
                    if (i < n)
                    {
                        string name = arr.Dequeue();
                        arr.Enqueue(name);
                    }
                    else if (i > n)
                    {

                        string name = arr.Dequeue();
                        arr.Enqueue(name);
                    }
                    else if (i == n)
                    {
                        Console.WriteLine($"Removed {arr.Dequeue()}");
                    }

                }
            }
            Console.WriteLine($"Last is {arr.Dequeue()}");
        }
    }
}
