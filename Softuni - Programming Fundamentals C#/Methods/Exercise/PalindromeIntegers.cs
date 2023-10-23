using System;
using System.Linq;

namespace PalindromeIntegers
{
    class PalindromeIntegers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            static bool isP(string str)
            {
                char[] arr = str.ToCharArray();
                Array.Reverse(arr);
                string rev = new string(arr);
                if (rev!=str)
                {
                    return false;
                }
                return true;
            }
            while (input!="END")
            {
                int number = int.Parse(input);
                string strNumber = number.ToString();
                bool isPalindrome = isP(strNumber);
                if (isPalindrome)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                input = Console.ReadLine();
            } 
        }
    }
}
