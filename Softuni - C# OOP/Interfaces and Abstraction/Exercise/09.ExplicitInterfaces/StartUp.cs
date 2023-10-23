using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            while (input[0]!="End")
            {
                Citizen person = new Citizen(input[0], int.Parse(input[2]), input[1]);
                person.GetName();
                input = Console.ReadLine().Split();
            }
        }
    }
}
