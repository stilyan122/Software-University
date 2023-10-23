using System;

namespace CharactersInRange
{
    class CharactersInRange
    {
        static void Main(string[] args)
        {
            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());
            PrintCharactersBetween(char1, char2);
        }
        public static void PrintCharactersBetween(char char1, char char2)
        {
            if (char2 < char1)
            {
                char temp = char1;
                char1 = char2;
                char2 = temp;
            }
            for (char c = (char)(char1 + 1); c < char2; c++)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
    }
}
