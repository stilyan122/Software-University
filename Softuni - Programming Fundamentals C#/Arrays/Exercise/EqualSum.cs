using System;
using System.Linq;

namespace EqualSum
{
    class EqualSum
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            bool isFound = false;

            for (int curr = 0; curr < array.Length; curr++)
            {
                int sumRight = 0;

                for (int i = curr + 1; i < array.Length; i++)
                {
                    sumRight += array[i];
                }

                int sumLeft = 0;

                for (int i = curr - 1; i >= 0; i--)
                {
                    sumLeft += array[i];
                }
                if (sumRight == sumLeft)
                {
                    Console.WriteLine(curr);
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("no");
            }
      
        }
    }
}
