using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] input = Console.ReadLine().Split();
                string[] input2 = Console.ReadLine().Split();
                Dough dough = new Dough(input2[1], input2[2], double.Parse(input2[3]));
                Pizza pizza = new Pizza(input[1], dough);
                string[] input3 = Console.ReadLine().Split();
                pizza.AddTopping(new Topping(input3[1], double.Parse(input3[2])));
                if (input3[0]!="END")
                {
                    input3 = Console.ReadLine().Split();
                    while (input3[0]!="END")
                    {
                        pizza.AddTopping(new Topping(input3[1], double.Parse(input3[2])));
                        input3 = Console.ReadLine().Split();
                    }
                }
                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
