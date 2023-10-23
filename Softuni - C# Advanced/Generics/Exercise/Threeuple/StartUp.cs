using System;
using System.Text;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] names1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name1 = names1[0] + " " + names1[1];
            string address = names1[2];
            StringBuilder sbTown = new StringBuilder();
            for (int i = 3; i < names1.Length; i++)
            {
                sbTown.Append(names1[i] + " ");
            }
            string town = sbTown.ToString();
            Threeuple<string, string, string> names = new Threeuple<string, string, string>(name1, address, town);
            string[] info1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name2 = info1[0];
            int liters = int.Parse(info1[1]);
            bool drunk = false;
            if (info1[2]=="drunk")
            {
                drunk = true;
            }
            Threeuple<string, int, bool> info = new Threeuple<string, int, bool>(name2, liters, drunk);
            string[] names2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name3 = names2[0];
            double balance = double.Parse(names2[1]);
            string bankName = names2[2];
            Threeuple<string, double, string> bank = new Threeuple<string, double, string>(name3, balance, bankName);
            Console.WriteLine(names.ToString());
            Console.WriteLine(info.ToString());
            Console.WriteLine(bank.ToString());
        }
    }
}
