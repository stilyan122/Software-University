using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize)
            :base(name,weight,foodEaten,wingSize)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
