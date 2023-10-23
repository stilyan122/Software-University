using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharsInAString
{
    class CountCharsInAString
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> occ = new Dictionary<string, int>();
            string input = Console.ReadLine();
            foreach (var item in input)
            {
                if (item.ToString()!=" ")
                {
                    if (!occ.ContainsKey(item.ToString()))
                    {
                        occ.Add(item.ToString(), 1);
                    }
                    else
                    {
                        occ[item.ToString()]++;
                    }
                }
            }
            foreach (var item in occ)
            {
                Console.WriteLine(item.Key+" -> "+item.Value);
            }
        }
    }
}
