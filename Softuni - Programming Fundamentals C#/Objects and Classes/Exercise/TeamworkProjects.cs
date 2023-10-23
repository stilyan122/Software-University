using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class TeamworkProjects
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("-");
                string user = input[0];
                string name = input[1];
                Team team = new Team(name, user);
                if (teams.Where(x=>x.Creater==user).ToList().Count!=0)
                {
                    Console.WriteLine($"{user} cannot create another team!");
                }
                else if (teams.Where(x=>x.Name==name).ToList().Count!=0)
                {
                    Console.WriteLine($"Team {name} was already created!");
                }
                else
                {
                    teams.Add(team);
                    Console.WriteLine($"Team {team.Name} has been created by {team.Creater}!");
                }
            }
            string[] command = Console.ReadLine().Split("->");
            while (command[0]!= "end of assignment")
            {
                string name = command[0];
                string team = command[1];
                if (teams.Where(x => x.Name == team).ToList().Count == 0)
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (teams.Where(x=>x.User.Contains(name)).ToList().Count!=0)
                {
                    Console.WriteLine($"Member {name} cannot join team {team}!");
                }
                else
                {
                    teams.Where(x => x.Name == team).ToList()[0].User.Add(name);
                }
                command = Console.ReadLine().Split("->");
            }
            List<Team> disbands = teams.Where(x => x.User.Count == 0).ToList().OrderByDescending(x => x.User.Count).ThenBy(x => x.Name).ToList();
            disbands.ForEach(x => x.User = x.User.OrderBy(d => d).ToList());
            teams = teams.Where(x => x.User.Count > 0).ToList().OrderByDescending(x => x.User.Count).ThenBy(x=>x.Name).ToList();
            teams.ForEach(x => x.User = x.User.OrderBy(d => d).ToList());
            foreach (var team in teams)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creater}");
                    for (int i = 0; i < team.User.Count; i++)
                    {
                        Console.WriteLine($"-- {team.User[i]}");
                    }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var team in disbands)
            {
                Console.WriteLine(team.Name);
            }
        }
    }
    public class Team
    {
        private string name;
        private string creator;
        private List<string> user;
        public Team(string name,string creator)
        {
            this.Name = name;
            this.User = new List<string>();
            this.Creater = creator;
        }
        public string Name { get; set; }
        public string Creater { get; set; }
        public List<string> User { get; set; }
    }
}
