using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSynonyms
{
    class WordSynonyms
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, new List<string>() { synonym });
                }
                else
                {
                    dictionary[word].Add(synonym);
                }
            }
            foreach (var item in dictionary)
            {
                Console.Write(item.Key+" - ");
                Console.WriteLine(string.Join(", ",item.Value));
            }
        }
    }
}
