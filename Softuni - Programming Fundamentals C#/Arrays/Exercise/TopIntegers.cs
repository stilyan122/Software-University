using System;
using System.Linq;

namespace TopIntegers
{
    class TopIntegers
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            bool IsBigger = true;

            for (int i = 0; i < arr.Length; i++)
            {
                int currentInteger = arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] >= currentInteger)
                    {
                        IsBigger = false;
                        break;
                    }
                }
                if (IsBigger)
                {
                    Console.Write(currentInteger + " ");
                }
                IsBigger = true;
            }
        }
    }
}
