using System;
using System.Linq;

namespace TextFilter
{
    class TextFilter
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();
            foreach (var word in words)
            {
                while (text.Contains(word))
                {
                    string stars = new string('*', word.Length);
                    text = text.Replace(word, stars);
                }
            }
            Console.WriteLine(text);
        }
    }
}
