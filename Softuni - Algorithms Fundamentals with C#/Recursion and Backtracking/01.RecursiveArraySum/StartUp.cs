using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    public class StartUp
    {
        static void Main()
        {
            var array = Console
                .ReadLine()?
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray() ?? new int[] { 1 };

            Console.WriteLine(RecursiveSum(array));
        }

        public static int RecursiveSum(int[] array)
        {
            if (array.Length == 1)
            {
                return array[0];
            }

            return array[0] + RecursiveSum(array.Where((item, index) => index > 0).ToArray());
        }
    }
}
