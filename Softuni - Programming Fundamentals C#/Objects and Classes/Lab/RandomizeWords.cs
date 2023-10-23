using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            List<string> arr = Console.ReadLine().Split(" ").ToList();
            for (int i = 0; i < arr.Count; i++)
            {
                Random r = new Random();
                int rnd = r.Next(0, arr.Count);
                Console.WriteLine(arr[rnd]);
                arr.RemoveAt(rnd);
                i--;
            }
        }
    }
}
