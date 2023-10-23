using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class ShoppingSpree
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            string[] inputPeople = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            string[] inputProducts = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in inputPeople)
            {
                string[] info = item.Split("=");
                string name = info[0];
                double money = double.Parse(info[1]);
                Person person = new Person(name,money);
                people.Add(person);
            }
            foreach (var item in inputProducts)
            {
                string[] info = item.Split("=");
                string name = info[0];
                double cost = double.Parse(info[1]);
                Product product = new Product(name, cost);
                products.Add(product);
            }
            string[] command = Console.ReadLine().Split();
            while (command[0]!="END")
            {
                string name = command[0];
                string product = command[1];
                Person currPerson = people.Where(x => x.Name == name).First();
                Product currProduct = products.Where(x => x.Name == product).First();
                if (currPerson.Money-currProduct.Cost>=0)
                {
                    currPerson.Bag.Add(currProduct.Name);
                    currPerson.Money -= currProduct.Cost;
                    Console.WriteLine($"{currPerson.Name} bought {currProduct.Name}");
                }
                else
                {
                    Console.WriteLine($"{currPerson.Name} can't afford {currProduct.Name}");
                }
                command = Console.ReadLine().Split();
            }
            foreach (var item in people)
            {
                Console.Write($"{item.Name} - ");
                if (item.Bag.Count > 0)
                    Console.WriteLine(string.Join(", ", item.Bag));
                else
                    Console.WriteLine("Nothing bought");
            }
        }
    }
    public class Product
    {
        private string name;
        private double cost;
        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public string Name { get; set; }
        public double Cost { get; set; }
    }
    public class Person
    {
        private string name;
        private double money;
        private List<string> bag;
        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = new List<string>();
        }
        public string Name { get; set; }
        public double Money { get; set; }
        public List<string> Bag { get; set; }
    }
}
