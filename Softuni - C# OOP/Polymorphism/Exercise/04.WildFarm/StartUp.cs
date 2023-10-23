using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] food = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<Animal> animals = new List<Animal>();
            while (input[0] != "End")
            {
                switch (input[0])
                {
                    case "Cat":
                        Cat cat = new Cat(input[1], double.Parse(input[2]), 0, input[3], input[4]);
                        cat.AskForFood();
                        if (food[0] == "Vegetable")
                        {
                            Vegetable vegetable = new Vegetable(int.Parse(food[1]));
                            cat.FoodEaten += vegetable.Quantity;
                            cat.Weight += 0.30*vegetable.Quantity;
                        }
                        else if (food[0] == "Meat")
                        {
                            Meat meat = new Meat(int.Parse(food[1]));
                            cat.FoodEaten += meat.Quantity;
                            cat.Weight += 0.30*meat.Quantity;
                        }
                        else
                        {
                            Console.WriteLine($"{cat.GetType().Name} does not eat {food[0]}!");
                        }
                        animals.Add(cat);
                        break;
                    case "Tiger":
                        Tiger tiger = new Tiger(input[1], double.Parse(input[2]), 0, input[3], input[4]);
                        tiger.AskForFood();
                        if (food[0] == "Meat")
                        {
                            Meat meat = new Meat(int.Parse(food[1]));
                            tiger.Weight += meat.Quantity * 1.00;
                            tiger.FoodEaten += meat.Quantity;
                        }
                        else
                        {
                            Console.WriteLine($"{tiger.GetType().Name} does not eat {food[0]}!");
                        }
                        animals.Add(tiger);
                        break;
                    case "Owl":
                        Owl owl = new Owl(input[1], double.Parse(input[2]), 0, double.Parse(input[3]));
                        owl.AskForFood();
                        if (food[0] == "Meat")
                        {
                            Meat meat = new Meat(int.Parse(food[1]));
                            owl.FoodEaten += meat.Quantity;
                            owl.Weight += meat.Quantity * 0.25;
                        }
                        else
                        {
                            Console.WriteLine($"{owl.GetType().Name} does not eat {food[0]}!");
                        }
                        animals.Add(owl);
                        break;
                    case "Hen":
                        Hen hen = new Hen(input[1], double.Parse(input[2]), 0, double.Parse(input[3]));
                        hen.AskForFood();
                        switch (food[0])
                        {
                            case "Meat":
                                Meat meat = new Meat(int.Parse(food[1]));
                                hen.Weight += meat.Quantity * 0.35;
                                hen.FoodEaten += meat.Quantity;
                                break;
                            case "Vegetable":
                                Vegetable veg = new Vegetable(int.Parse(food[1]));
                                hen.Weight += veg.Quantity * 0.35;
                                hen.FoodEaten += veg.Quantity;
                                break;
                            case "Fruit":
                                Fruit fruit = new Fruit(int.Parse(food[1]));
                                hen.Weight += fruit.Quantity * 0.35;
                                hen.FoodEaten += fruit.Quantity;
                                break;
                            case "Seeds":
                                Seeds seeds = new Seeds(int.Parse(food[1]));
                                hen.Weight += seeds.Quantity * 0.35;
                                hen.FoodEaten += seeds.Quantity;
                                break;
                            default:
                                break;
                        }
                        animals.Add(hen);
                        break;
                    case "Mouse":
                        Mouse mouse = new Mouse(input[1], double.Parse(input[2]), 0, input[3]);
                        mouse.AskForFood();
                        if (food[0]=="Vegetable")
                        {
                            Vegetable vegetable = new Vegetable(int.Parse(food[1]));
                            mouse.Weight += vegetable.Quantity*0.10;
                            mouse.FoodEaten += vegetable.Quantity;
                        }
                        else if (food[0] == "Fruit")
                        {
                            Fruit fruit = new Fruit(int.Parse(food[1]));
                            mouse.Weight += fruit.Quantity * 0.10;
                            mouse.FoodEaten += fruit.Quantity;
                        }
                        else
                        {
                            Console.WriteLine($"{mouse.GetType().Name} does not eat {food[0]}!");
                        }
                        animals.Add(mouse);
                        break;
                    case "Dog":
                        Dog dog = new Dog(input[1], double.Parse(input[2]), 0, input[3]);
                        dog.AskForFood();
                        if (food[0] == "Meat")
                        {
                            Meat meat = new Meat(int.Parse(food[1]));
                            dog.Weight += meat.Quantity*0.40;
                            dog.FoodEaten += meat.Quantity;
                        }
                        else
                        {
                            Console.WriteLine($"{dog.GetType().Name} does not eat {food[0]}!");
                        }
                        animals.Add(dog);
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "End")
                {
                    break;
                }
                food = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
