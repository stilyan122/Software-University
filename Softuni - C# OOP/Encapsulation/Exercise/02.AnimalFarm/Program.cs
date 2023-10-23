namespace AnimalFarm
{
    using System;
    using AnimalFarm.Models;
    class Program
    {
        static void Main(string[] args)
        {
            Chicken chicken = new Chicken("name", 10);
            bool thrownException = false;
            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                chicken = new Chicken(name, age);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                thrownException = true;
            }
            if (thrownException==false)
            {
                Console.WriteLine(
                    "Chicken {0} (age {1}) can produce {2} eggs per day.",
                    chicken.Name,
                    chicken.Age,
                    chicken.ProductPerDay);
            }
        }
    }
}
