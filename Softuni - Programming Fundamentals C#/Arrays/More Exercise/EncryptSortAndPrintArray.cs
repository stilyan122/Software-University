using System;
using System.Linq;

namespace EncryptSortAndPrintArray
{
    class EncryptSortAndPrintArray
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] array = new string[n];
            int[] crypt = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = Console.ReadLine();
            }
            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                string current = array[i];
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (current[j].ToString().ToLower() == "a" || 
                        current[j].ToString().ToLower() == "u" ||
                        current[j].ToString().ToLower() == "e" ||
                        current[j].ToString().ToLower() == "i" ||
                        current[j].ToString().ToLower() == "o")
                    {
                        sum += (int)current[j] * current.Length;
                    }
                    else
                    {
                        sum += (int)current[j] / current.Length;
                    }
                }
                crypt[i] = sum;
            }
            crypt = crypt.OrderBy(x => x).ToArray();
            foreach (var code in crypt)
            {
                Console.WriteLine(code);
            }
        }
    }
}
