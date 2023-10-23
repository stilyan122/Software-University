using System;

namespace MiddleCharacters
{
    class MiddleCharacters
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string result = PrintMiddleCharacter(str);
            Console.WriteLine(result);
        }
        static string PrintMiddleCharacter(string input)
        {
            int length = input.Length;
            int middleIndex = length / 2;
            if (length % 2 == 0)
            {
              
               return (input[middleIndex - 1].ToString()+input[middleIndex].ToString()).ToString();
            }
            else
            {
                return input[middleIndex].ToString();
            }
        }
    }
}
