using System;
using System.Collections.Generic;
using System.Linq;

namespace AMinerTask
{
    class AMinerTask
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string quantityInput = Console.ReadLine();
            Dictionary<string, double> output = new Dictionary<string, double>();
            while (command!="stop"&&quantityInput!="stop")
            {
                double quantity = double.Parse(quantityInput);
                if (!output.ContainsKey(command))
                {
                    output.Add(command, quantity);
                }
                else
                {
                    output[command] += quantity;
                }
                command = Console.ReadLine();
                if (command == "stop")
                {
                    break;
                }
                quantityInput = Console.ReadLine();
                if (quantityInput == "stop")
                {
                    break;
                }
            }
            foreach (var item in output)
            {
                Console.WriteLine(item.Key+" -> "+item.Value);
            }
        }
    }
}
