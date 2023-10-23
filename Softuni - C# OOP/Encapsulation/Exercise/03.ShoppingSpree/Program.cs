using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{

    public class Program
    {
        public static void Main()
        {
            var people = new List<Person>();
            var products = new List<Product>();
            var peopleInput = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var productsInput = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (var token in peopleInput)
                {
                    var tokens = token.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = tokens[0];
                    var money = double.Parse(tokens[1]);

                    var person = new Person(name, money);
                    people.Add(person);
                }

                foreach (var token in productsInput)
                {
                    var info = token.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = info[0];
                    var cost = double.Parse(info[1]);

                    var product = new Product(name, cost);
                    products.Add(product);
                }

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    var info = command.Split();
                    var personName = info[0];
                    var productName = info[1];
                    var product = products.FirstOrDefault(p => p.Name == productName);

                    try
                    {
                        people.FirstOrDefault(p => p.Name == personName)
                              .BuyProduct(product);
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                foreach (var per in people)
                {
                    Console.WriteLine(per.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}