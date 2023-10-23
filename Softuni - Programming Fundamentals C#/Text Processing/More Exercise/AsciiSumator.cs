using System;
using System.Linq;
using System.Text;

namespace AsciiSumator
{
    class AsciiSumator
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            int sum = 0;
            string str = Console.ReadLine();
            for (int i = 0; i < str.Length; i++)
            {
                if(str[i] > firstChar && str[i] < secondChar)
                sum += (int)str[i];
            }
            Console.WriteLine(sum);
        }
    }
}
