using System;

namespace DataTypes
{
    class DataTypes
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            switch (type)
            {
                case "int":
                    int n1 = int.Parse(Console.ReadLine());
                    Console.WriteLine(Task(n1));
                    break;
                case "real":
                    double n2 = double.Parse(Console.ReadLine());
                    Console.WriteLine((Task(n2)));
                    break;
                case "string":
                    string n3 = Console.ReadLine();
                    Console.WriteLine(Task(n3));
                    break;
            }
        }
        public static int Task(int n)
        {
            return 2 * n;
        }
        public static string Task(double n)
        {
            return $"{(1.5 * n):f2}";
        }
        public static string Task(string n)
        {
            return "$" + n + "$";
        }
    }
}
