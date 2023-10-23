using System;
using System.Collections.Generic;

namespace ProductShop
{
    class ProductShop
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(", ");
            SortedDictionary<string, Dictionary<string, double>> shopInfo = new SortedDictionary<string, Dictionary<string, double>>();
            while (command[0] != "Revision")
            {
                if (command[0] == "Revision")
                {
                    break;
                }
                else
                {
                    string shopName = command[0];
                    Dictionary<string, double> product = new Dictionary<string, double>();
                    product.Add(command[1], double.Parse(command[2]));
                    if (!shopInfo.ContainsKey(shopName))
                    {
                        shopInfo.Add(shopName, product);
                    }
                    else
                    {
                        shopInfo[shopName].Add(command[1], double.Parse(command[2]));
                    }
                }
                command = Console.ReadLine().Split(", ");
            }
            foreach (var item in shopInfo)
            {
                Console.WriteLine(item.Key + "->");
                foreach (var item1 in item.Value)
                {
                    Console.WriteLine($"Product: {item1.Key}, Price: {item1.Value}");
                }
            }
        }
    }
}
