using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class FilterByAge
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();
            List<int> ages = new List<int>();
            Dictionary<string, int> check = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine()
                .Split(", ");
                int value2 = int.Parse(arr[1]);
                string value1 = arr[0];
                names.Add(value1);
                ages.Add(value2);
            }
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine()
                .Split(" ");
            Func<string, int, bool> younger = (name, age1) => age1 < age;
            Func<string, int, bool> older = (name, age1) => age1 >= age;
            if (condition == "younger")
            {
                foreach (var item1 in names)
                {
                    foreach (var item2 in ages)
                    {
                        if (younger(item1, item2) == true)
                        {
                            check.Add(item1, item2);
                            ages.Remove(item2);
                            break;
                        }
                        else
                        {
                            ages.Remove(item2);
                            break;
                        }
                    }
                }
            }
            else if (condition == "older")
            {
                for (int i = 0; i < n; i++)
                {
                    foreach (var item1 in names)
                    {
                        foreach (var item2 in ages)
                        {
                            if (older(item1, item2) == true)
                            {
                                check.Add(item1, item2);
                                ages.Remove(item2);
                                break;
                            }
                            else
                            {
                                ages.Remove(item2);
                                break;
                            }
                        }
                    }
                }
            }
            if (format.Length == 2)
            {
                NameAge(check);
            }
            else if (format[0] == "name")
            {
                Name(check);
            }
            else if (format[0] == "age")
            {
                Age(check);
            }
        }
        public static void Name(Dictionary<string, int> names)
        {
            foreach (var item in names)
            {
                Console.WriteLine(item.Key);
            }
        }
        public static void Age(Dictionary<string, int> ages)
        {
            foreach (var item in ages)
            {
                Console.WriteLine(item.Value);
            }
        }
        public static void NameAge(Dictionary<string, int> info)
        {
            foreach (var item in info)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
