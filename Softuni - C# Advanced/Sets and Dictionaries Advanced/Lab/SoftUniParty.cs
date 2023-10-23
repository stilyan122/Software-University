using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            string guest = Console.ReadLine();
            HashSet<string> invited = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();
            bool isEnd = false;
            HashSet<string> vip = new HashSet<string>();
            while (guest != "END")
            {
                if (guest != "END" && guest != "PARTY")
                {
                    invited.Add(guest);
                    if (char.IsDigit(guest[0]))
                    {
                        vip.Add(guest);
                    }
                    else
                    {
                        regular.Add(guest);
                    }
                }
                else if (guest == "PARTY")
                {
                    while (guest != "END")
                    {
                        guest = Console.ReadLine();
                        if (guest == "END")
                        {
                            isEnd = true;
                            break;
                        }
                        else
                        {
                            if (invited.Contains(guest) && vip.Contains(guest))
                            {
                                vip.Remove(guest);
                            }
                            else if (invited.Contains(guest) && regular.Contains(guest))
                            {
                                regular.Remove(guest);
                            }
                        }
                    }

                }
                if (guest == "END" || isEnd == true)
                {
                    break;
                }
                guest = Console.ReadLine();
            }
            int count = vip.Count + regular.Count;
            Console.WriteLine(count);
            if (vip.Count > 0)
            {
                foreach (var item in vip)
                {
                    Console.WriteLine(item);
                }
            }
            if (regular.Count > 0)
            {
                foreach (var item in regular)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
