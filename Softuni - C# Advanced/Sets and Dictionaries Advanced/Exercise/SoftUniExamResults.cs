using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class SoftUniExamResults
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            Dictionary<string, KeyValuePair<string, int>> users = new Dictionary<string, KeyValuePair<string, int>>();
            string[] inputUsers = Console.ReadLine().Split("-");
            while (inputUsers[0]!="exam finished")
            {
                if (inputUsers.Length == 3)
                {
                    string name = inputUsers[0];
                    string language = inputUsers[1];
                    int points = int.Parse(inputUsers[2]);
                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 1);
                    }
                    else
                    {
                        submissions[language]++;
                    }
                    if(!users.ContainsKey(name))
                    users.Add(name, new KeyValuePair<string, int>(language, points));
                    else
                    {
                        if (users[name].Value<points)
                        {
                            users.Remove(name);
                            users.Add(name, new KeyValuePair<string, int>(language, points));
                        }
                    }
                }
                else
                {
                    string name = inputUsers[0];
                    users.Remove(name);
                }
                inputUsers = Console.ReadLine().Split("-");
            }
            if (users.Count>0)
            {
                Console.WriteLine("Results:");
                foreach (var user in users.OrderByDescending(x=>x.Value.Value).ThenBy(x=>x.Key))
                {
                    Console.WriteLine($"{user.Key} | {user.Value.Value}");
                }
            }
            if (submissions.Count>0)
            {
                Console.WriteLine("Submissions:");
                foreach (var submission in submissions.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
                {
                    Console.WriteLine($"{submission.Key} - {submission.Value}");
                }
            }
        }
    }
}
