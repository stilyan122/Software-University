using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvertisementMessage
{
    class AdvertisementMessage
    {
        static void Main(string[] args)
        {
            List<string> phrases = new List<string>()
            {
               "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product."
            };
            List<string> events = new List<string>()
            {
                "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };
            List<string> authors = new List<string>()
            {
                "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
            };
            List<string> towns = new List<string>()
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };
            Random rnd = new Random();
            List<string> messages = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                messages.Add($"{phrases[rnd.Next(0,phrases.Count)]} {events[rnd.Next(0, events.Count)]} {authors[rnd.Next(0, authors.Count)]} - {towns[rnd.Next(0, towns.Count)]}");
            }
            foreach (var item in messages)
            {
                Console.WriteLine(item);
            }
        }
    }
}
