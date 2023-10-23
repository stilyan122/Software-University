using System;
using System.Linq;

namespace EqualArrays
{
    class EqualArrays
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (array1.Length > array2.Length)
            {
                for (int i = 0; i < array2.Length; i++)
                {
                    if (array1[i] != array2[i])
                    {
                        Console.WriteLine($"Arrays are not identical. Found difference at {i} index.");
                        break;
                    }
                }
            }
            else if (array1.Length < array2.Length)
            { 
                for (int i = 0; i < array1.Length; i++)
                {
                    if (array1[i] != array2[i])
                    {
                        Console.WriteLine($"Arrays are not identical. Found difference at {i} index.");
                        break;
                    }
                }
            }
            else
            {
                bool areEq = true;
                for (int i = 0; i < array1.Length; i++)
                {
                    if (array1[i] != array2[i])
                    {
                        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                        areEq = false;
                        break;
                    }
                }
                if (areEq)
                {
                    Console.WriteLine($"Arrays are identical. Sum: {array1.Sum()}");
                }
            }
        }
    }
}
