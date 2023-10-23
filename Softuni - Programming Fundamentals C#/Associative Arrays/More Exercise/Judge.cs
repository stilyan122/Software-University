using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Judge
    {
        static void Main(string[] args)
        {
            Dictionary<string,Dictionary<string,int>> contests = new Dictionary<string, Dictionary<string, int>>();
            SortedDictionary<string, Dictionary<string, int>> individualStatistics = new SortedDictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "no more time")
            {
                string name = input.Split(" -> ")[0].ToString();
                string contest = input.Split(" -> ")[1].ToString();
                int points = int.Parse(input.Split(" -> ")[2].ToString());

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest].ContainsKey(name))
                    {
                        if (contests[contest][name] < points)
                        {
                            contests[contest][name] = points;
                        }
                    }
                    else
                    {
                        contests[contest].Add(name, points);
                    }
                }
                else
                {
                    contests.Add(contest, new Dictionary<string, int>());
                    contests[contest].Add(name, points);
                }

                if (individualStatistics.ContainsKey(name))
                {
                    if (individualStatistics[name].ContainsKey(contest))
                    {
                        if (individualStatistics[name][contest] < points)
                        {
                            individualStatistics[name][contest] = points;
                        }
                    }
                    else
                    {
                        individualStatistics[name].Add(contest, points);
                    }
                }
                else
                {
                    individualStatistics.Add(name, new Dictionary<string, int>());
                    individualStatistics[name].Add(contest, points);
                }
                input = Console.ReadLine();
            }
            int position = 1;
            foreach (var item in contests)
            {
                position = 1;
                Console.WriteLine($"{item.Key}: {item.Value.Count} participants");

                foreach (var items in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key)) 
                {
                    Console.WriteLine($"{position}. {items.Key} <::> {items.Value}");
                    position++;
                }
            }
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int sum = 0;
            foreach (var item in individualStatistics)
            {
                foreach (var items in item.Value)
                {
                    sum += items.Value;
                }
                dic.Add(item.Key, sum);
                sum = 0;
            }

            dic = dic.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(a => a.Key, b => b.Value);

            position = 1;
            Console.WriteLine("Individual standings:");
            foreach (var item in dic)
            {
                Console.WriteLine($"{position}. {item.Key} -> {item.Value}");
                position++;
            }
        }
    }
}

