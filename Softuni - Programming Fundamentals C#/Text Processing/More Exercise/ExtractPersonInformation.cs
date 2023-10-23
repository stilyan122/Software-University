using System;

namespace ExtractPersonInformation
{
    class ExtractPersonInformation
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int index1 = input.IndexOf("@") + 1;
                int index2 = input.IndexOf("|") - 1;
                string name = input.Substring(index1, index2 - index1 + 1);
                int index3 = input.IndexOf("#") + 1;
                int index4 = input.IndexOf("*") - 1;
                string age = input.Substring(index3, index4 - index3 + 1);
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
