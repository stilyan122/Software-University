using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten,string region, string breed)
            :base(name,weight,foodEaten,region,breed)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void AskForFood()
        {
            Console.WriteLine("Meow");
        }
    }
}
