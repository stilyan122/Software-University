using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            AddCollection collection1 = new AddCollection(new List<string>());
            AddRemoveCollection collection2 = new AddRemoveCollection(new List<string>());
            MyList collection3 = new MyList(new List<string>());
            for (int i = 0; i < input.Count; i++)
            {
                collection1.Add(input[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < input.Count; i++)
            {
                collection2.Add(input[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < input.Count; i++)
            {
                collection3.Add(input[i]);
            }
            Console.WriteLine();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                collection2.Remove();
            }
            Console.WriteLine();
            for (int i = 0; i < count; i++)
            {
                collection3.Remove();
            }
            Console.WriteLine();
        }
    }
}
