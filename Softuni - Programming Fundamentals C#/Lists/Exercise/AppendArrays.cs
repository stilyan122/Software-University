using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class AppendArrays
    {
        static void Main()
        {
            List<string> input = Console.ReadLine().Split('|').ToList();
            List<string> result = new List<string>();

            for (int i = input.Count - 1; i >= 0; i--)
            {
                var currentList = input[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in currentList)
                {
                    result.Add(item);
                }

            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
