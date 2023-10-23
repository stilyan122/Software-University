using System;

namespace VowelsCount
{
    class VowelsCount
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int vowels = CountVowels(input);
            Console.WriteLine(vowels);
        }
        public static int CountVowels(string input)
        {
            int vowelCount = 0;
            input = input.ToLower();
            foreach (char c in input)
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    vowelCount++;
                }
            }
            return vowelCount;
        }
    }
}
