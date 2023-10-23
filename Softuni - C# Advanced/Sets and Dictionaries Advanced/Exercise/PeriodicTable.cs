using System;
using System.Linq;
using System.Collections.Generic;

namespace PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] compound = Console.ReadLine().Split();
                foreach (var item in compound)
                {
                    elements.Add(item);
                }
            }
            List<string> list = elements.ToList();
            list.Sort();
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
    }
}
