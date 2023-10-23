using System;
using System.Linq;
using System.Collections.Generic;

namespace ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<int> deviders = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> numbers = new List<int>();
            for (int i = 1; i <= length; i++)
            {
                if (DevidersInfo(i, deviders))
                {
                    numbers.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
        private static bool DevidersInfo(int n, List<int> dividers)
        {
            bool isTrue = true;
            foreach (int divider in dividers)
            {
                if (n % divider != 0)
                {
                    isTrue = false;
                }
            }
            return isTrue;
        }
    }
}
