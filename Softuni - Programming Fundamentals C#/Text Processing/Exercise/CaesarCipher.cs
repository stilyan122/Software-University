using System;
using System.Linq;
using System.Text;

namespace CaesarCipher
{
    class CaesarCipher
    {
        static void Main(string[] args)
        {
            StringBuilder encrypted = new StringBuilder();
            string input = Console.ReadLine();
            foreach (var item in input)
            {
                char encrypt = (char)((int)item + 3);
                encrypted.Append(encrypt);
            }
            Console.WriteLine(encrypted.ToString());
        }
    }
}
