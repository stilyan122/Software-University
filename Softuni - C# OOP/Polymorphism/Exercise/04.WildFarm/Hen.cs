using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void AskForFood()
        {
            Console.WriteLine("Cluck");
        }
    }
}
