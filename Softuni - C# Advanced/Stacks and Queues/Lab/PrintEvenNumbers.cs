using System;
using System.Linq;
using System.Collections.Generic;

namespace PrintEvenNumbers
{
    class PrintEvenNumbers
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<string> qu = new Queue<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    qu.Enqueue(arr[i].ToString());
                }
            }
            string[] arr2 = qu.ToArray();
            Console.WriteLine(string.Join(", ", arr2));
        }
    }
}
