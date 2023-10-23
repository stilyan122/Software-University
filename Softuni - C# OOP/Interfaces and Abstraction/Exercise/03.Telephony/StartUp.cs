using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StationaryPhone phone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();
            List<string> numbers = Console.ReadLine().Split(" ").ToList();
            List<string> websites = Console.ReadLine().Split(" ").ToList();
            foreach (var number in numbers)
            {
                bool isValid = true;
                foreach (var character in number)
                {
                    if (!char.IsDigit(character))
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid == true && number.Length == 10)
                {
                    smartphone.Call(number);
                }
                else if(isValid==true && number.Length == 7)
                {
                    phone.Call(number);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            smartphone.Browse(websites);
        }
    }
}
