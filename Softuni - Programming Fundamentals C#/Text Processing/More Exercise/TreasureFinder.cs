using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TreasureFinder
{
    class TreasureFinder
    {
        static void Main(string[] args)
        {
            double[] keys = Console.ReadLine().Split().Select(double.Parse).ToArray();
            string str = Console.ReadLine();
            while (str != "find")
            {
                StringBuilder output = new StringBuilder();
                int i = 0;
                int j = 0;
                while (i < str.Length)
                {
                    if (j + 1 <= keys.Length)
                    {
                        output.Append((char)((int)str[i] - (int)keys[j]));
                        i++;
                        j++;
                    }
                    else
                    {
                        j = 0;
                    }
                }
                int index1 = output.ToString().IndexOf("&");
                string outputStr =  output.ToString().Remove(index1, 1);
                int index2 = outputStr.ToString().IndexOf("&")-1;
                string type = output.ToString().Substring(index1+1, index2 - index1 + 1);
                int index3 = output.ToString().IndexOf("<");
                int index4 = output.ToString().IndexOf(">");
                string cord = output.ToString().Substring(index3 + 1, index4 - index3 - 1);
                Console.WriteLine($"Found {type} at {cord}");
                str = Console.ReadLine();
            }
        }
    }
}
