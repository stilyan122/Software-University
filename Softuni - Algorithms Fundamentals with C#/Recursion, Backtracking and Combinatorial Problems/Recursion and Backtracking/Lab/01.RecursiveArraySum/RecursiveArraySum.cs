using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursiveArraySum
{
    public class RecursiveArraySum
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int Sum(int index, int[] array)
            {
                if (index < array.Length - 1)
                    return array[index] + Sum(index + 1, array);
                else
                    return array[index];
            }
            Console.WriteLine(Sum(0,array));
        }
    }
}
