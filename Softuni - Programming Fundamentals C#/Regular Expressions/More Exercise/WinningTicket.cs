using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class WinningTicket
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"(\@{6,}|\${6,}|\^{6,}|\#{6,})";
            Regex regex = new Regex(pattern);
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i].Length == 20)
                {
                    Match half1 = regex.Match(tickets[i].Substring(0, 10));
                    Match half2 = regex.Match(tickets[i].Substring(10));
                    int minLength = Math.Min(half1.Length, half2.Length);

                    if (half1.Success && half2.Success)
                    {
                        string win1 = half1.Value.Substring(0, minLength);
                        string win2 = half2.Value.Substring(0, minLength);

                        if (win1.Equals(win2))
                        {
                            if (win1.Length == 10)
                            {
                                Console.WriteLine($"ticket \"{tickets[i]}\" - {minLength}{win1.Substring(0, 1)} Jackpot!");
                            }
                            else
                            {
                                Console.WriteLine($"ticket \"{tickets[i]}\" - {minLength}{win1.Substring(0, 1)}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{tickets[i]}\" - no match");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{tickets[i]}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}
