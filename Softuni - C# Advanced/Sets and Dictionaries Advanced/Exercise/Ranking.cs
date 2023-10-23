using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>(); 
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string[] input = Console.ReadLine().Split(":",StringSplitOptions.RemoveEmptyEntries);
            while (input[0]!="end of contests")
            {
                string name = input[0];
                string password = input[1];
                contests.Add(name, password);
                input = Console.ReadLine().Split(":",StringSplitOptions.RemoveEmptyEntries);
            }
            string[] user = Console.ReadLine().Split("=>");
            while (user[0]!= "end of submissions")
            {
                string contest = user[0];
                string password = user[1];
                string username = user[2];
                int points = int.Parse(user[3]);
                if (contests.ContainsKey(contest))
                {
                    if (contests[contest]==password)
                    {
                        if (!users.ContainsKey(username))
                        {
                            users.Add(username, new Dictionary<string, int>());
                            users[username].Add(contest, points);
                        }
                        else
                        
                        {
                            if (!users[username].ContainsKey(contest))
                            {
                                users[username].Add(contest, points);
                            }
                            else
                            {
                                if (users[username][contest] < points)
                                {
                                    users[username][contest] = points;
                                }
                            }
                        }
                    }
                }
                user = Console.ReadLine().Split("=>");
            }
            int maxPoints = 0;
            string maxName = "";
            for (int i = 0; i < users.Count; i++)
            {
                int sum = 0;
                string currName = users.Keys.ToList()[i];
                for (int j = 0; j < users.Values.ToList()[i].Values.Count; j++)
                {
                    sum += users.Values.ToList()[i].Values.ToList()[j];
                }
                if (sum>maxPoints)
                {
                    maxPoints = sum;
                    maxName = currName;
                }
            }
            if(maxPoints>0&&maxName!="")
            Console.WriteLine($"Best candidate is {maxName} with total {maxPoints} points.");
            if (users.Count > 0)
            {
                Console.WriteLine("Ranking: ");
                foreach (var person in users.OrderBy(x => x.Key))
                {
                    Console.WriteLine(person.Key);
                    foreach (var contest in person.Value.OrderByDescending(x => x.Value))
                    {
                        Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                    }
                }
            }
        }
    }
}
