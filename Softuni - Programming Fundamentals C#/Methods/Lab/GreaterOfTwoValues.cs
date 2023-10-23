using System;

namespace GreaterOfTwoValues
{
    class GreaterOfTwoValues
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            switch (type)
            {
                case "int":
                    int n1 = int.Parse(Console.ReadLine());
                    int n2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(n1,n2));
                    break;
                case "char":
                    char char1 = char.Parse(Console.ReadLine());
                    char char2 = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(char1, char2));
                    break;
                case "string":
                    string string1 = Console.ReadLine();
                    string string2 = Console.ReadLine();
                    Console.WriteLine(GetMax(string1, string2));
                    break;
            }
        }
        static int GetMax(int val1, int val2)
        {
            return val1 > val2 ? val1 : val2;
        }

        static char GetMax(char val1, char val2)
        {
            return val1 > val2 ? val1 : val2;
        }

        static string GetMax(string val1, string val2)
        {
            return val1.CompareTo(val2) > 0 ? val1 : val2;
        }
    }
}
