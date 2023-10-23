using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class CitiesByContinentAndCountry
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> information = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string continent = info[0];
                string country = info[1];
                string city = info[2];
                if (!information.ContainsKey(continent))
                {
                    Dictionary<string, List<string>> names = new Dictionary<string, List<string>>();
                    names.Add(country, new List<string>() { city });
                    information.Add(continent, names);
                }
                else
                {
                    if (!information[continent].ContainsKey(country))
                    {
                        information[continent].Add(country, new List<string>() { city });
                    }
                    else
                    {
                        if (!information[continent][country].Contains(city))
                        {
                            information[continent][country].Add(city);
                        }
                        else
                        {
                            information[continent][country].Add(city);
                        }
                    }
                }
            }
            foreach (var item in information)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var item1 in item.Value)
                {
                    Console.WriteLine($"   {item1.Key} -> {string.Join(", ", item1.Value)}");
                }
            }
        }
    }
}
