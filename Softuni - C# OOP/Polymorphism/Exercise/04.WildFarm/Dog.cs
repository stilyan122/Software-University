using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name,double weight, int foodEaten, string region)
            :base(name,weight,foodEaten,region)
        {

        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]".ToString();
        }
        public override void AskForFood()
        {
            Console.WriteLine("Woof!");
        }
    }
}
