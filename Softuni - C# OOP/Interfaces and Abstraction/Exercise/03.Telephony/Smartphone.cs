using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public void Browse(List<string> websites)
        {
            foreach (var site in websites)
            {
                string web = site.ToString();
                bool validSite = true;
                foreach (var character in web)
                {
                    if (char.IsDigit(character))
                    {
                        Console.WriteLine("Invalid URL!");
                        validSite = false;
                        break;
                    }
                }
                if (validSite)
                {
                    Console.WriteLine($"Browsing: {site}!");
                }
            }

        }

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
