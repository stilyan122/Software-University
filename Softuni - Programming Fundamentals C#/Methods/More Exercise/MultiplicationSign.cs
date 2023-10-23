using System;
using System.Linq;

namespace MultiplicationSign
{
    class MultiplicationSign
    {
        static void Main(string[] args)
        {
            string n1 = double.Parse(Console.ReadLine()).ToString();
            string n2 = double.Parse(Console.ReadLine()).ToString();
            string n3 = double.Parse(Console.ReadLine()).ToString();
            IdentifySymbol(n1, n2, n3);
        }
        static void IdentifySymbol(string n1,string n2,string n3)
        {
            string allSymbols = n1 + n2 + n3;
            int count = 0;
            for (int i = 0; i < allSymbols.Length; i++)
            {
                string current = allSymbols[i].ToString();
                if (current=="-")
                {
                    count++;
                }
            }
            if (allSymbols.Contains("0"))
            {
                Console.WriteLine("zero");
            }
            else if (count==2 || count==0)
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }
        }
    }
}
