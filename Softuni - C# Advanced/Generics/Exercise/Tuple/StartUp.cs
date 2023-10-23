using System;
using System.Text;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name1 = names[0] + " " + names[1];
            StringBuilder adressSb = new StringBuilder();
            for (int i = 2; i < names.Length; i++)
            {
                adressSb.Append(names[i] + " ");
            }
            string address = adressSb.ToString();
            Tuple<string, string> tuple1 = new Tuple<string, string>(name1,address);
            string[] person = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name2 = person[0];
            int liters = int.Parse(person[1]);
            Tuple<string, int> tuple2 = new Tuple<string, int>(name2, liters);
            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int integer = int.Parse(numbers[0]);
            double doubler = double.Parse(numbers[1]);
            Tuple<int, double> tuple3 = new Tuple<int, double>(integer,doubler);
            Console.WriteLine(tuple1.ToString());
            Console.WriteLine(tuple2.ToString());
            Console.WriteLine(tuple3.ToString());

        }
    }
}
