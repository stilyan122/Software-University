using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    class ThePartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            List<string> filters = new List<string>();
            string input = Console.ReadLine();
            while (input != "Print")
            {
                string[] data = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "Add filter")
                {
                    filters.Add(data[1] + " " + data[2]);
                }
                else if (data[0] == "Remove filter")
                {
                    filters.Remove(data[1] + " " + data[2]);
                }
                input = Console.ReadLine();
            }
            foreach (var filter in filters)
            {
                string[] commands = filter.Split(" ");

                if (commands[0] == "Starts")
                {
                    guests = guests.Where(p => !p.StartsWith(commands[2])).ToList();
                }
                else if (commands[0] == "Ends")
                {
                    guests = guests.Where(p => !p.EndsWith(commands[2])).ToList();
                }
                else if (commands[0] == "Length")
                {
                    guests = guests.Where(p => p.Length != int.Parse(commands[1])).ToList();
                }
                else if (commands[0] == "Contains")
                {
                    guests = guests.Where(p => !p.Contains(commands[1])).ToList();
                }
            }
            if (guests.Any())
            {
                Console.WriteLine(string.Join(" ", guests));
            }
        }
    }
}
