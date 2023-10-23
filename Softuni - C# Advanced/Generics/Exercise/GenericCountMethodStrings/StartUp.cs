using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            static int Count<T>(List<T> list,T element) where T:IComparable<T>
            {
                int counter = 0;
                foreach (var item in list)
                {
                    if (item.CompareTo(element)>0)
                    {
                        counter++;
                    }
                }
                return counter;
            }
            List<string> items = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string item = Console.ReadLine();
                items.Add(item);
            }
            string comprarer = Console.ReadLine();
            int count = Count<string>(items,comprarer);
            Console.WriteLine(count);
        }
    }
}
