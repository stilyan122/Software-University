using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBAChallenger
{
    class MOBAChallenger
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();
            while (string.Join(" ",input) !="Season end")
            {
                if (input.Length > 1)
                {
                    if (input[1] == "->")
                    {
                        string[] inputPlayer = string.Join(" ", input).Split(" -> ");
                        string name = inputPlayer[0];
                        string position = inputPlayer[1];
                        int skill = int.Parse(inputPlayer[2]);
                        if (!players.ContainsKey(name))
                        {
                            Dictionary<string, int> stats = new Dictionary<string, int>();
                            stats.Add(position, skill);
                            players.Add(name, stats);
                        }
                        else
                        {
                            if (!players[name].ContainsKey(position))
                            {
                                players[name].Add(position, skill);
                            }
                            else
                            {
                                if (skill < players[name].Values.ToList()[0])
                                {
                                    players[name].Values.ToList()[0] = skill;
                                }
                            }
                        }
                    }
                    else if (input[1] == "vs")
                    {
                        string[] inputPlayers = string.Join(" ", input).Split(" vs ");
                        string player1 = inputPlayers[0];
                        string player2 = inputPlayers[1];
                        if (players.ContainsKey(player1) && players.ContainsKey(player2))
                        {
                            string playerToRemove = "";
                            if (players[player1].Count > 0 && players[player2].Count > 0)
                            {
                                foreach (var skill in players[player1])
                                {
                                    string curr = skill.Key;
                                    foreach (var skill2 in players[player2])
                                    {
                                        if (skill2.Key == curr)
                                        {
                                            int currSkill1 = skill.Value;
                                            int currSkill2 = skill2.Value;
                                            if (currSkill1 > currSkill2)
                                            {
                                                playerToRemove = player2;
                                                break;
                                            }
                                            else if (currSkill1 < currSkill2)
                                            {
                                                playerToRemove = player1;
                                                break;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            players.Remove(playerToRemove);
                        }
                    }
                }
                input = Console.ReadLine().Split();
            }
            foreach (var player in players.OrderByDescending(x=>x.Value.Values.Sum()).ThenBy(x=>x.Key))
            {
                int sum = player.Value.Values.Sum();
                Console.WriteLine(player.Key + ": " +sum+" skill");
                foreach (var skill in player.Value.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
                {
                    Console.WriteLine("- "+skill.Key+" <::> "+skill.Value);
                }
            }
        }
    }
}
