using System;
using System.Linq;

namespace Substring
{
    class Substring
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string str2 = Console.ReadLine();
            while (str2.Contains(str))
            {
                int index = str2.IndexOf(str);
                str2 = str2.Remove(index, str.Length);
            }
            Console.WriteLine(str2);
        }
    }
}
