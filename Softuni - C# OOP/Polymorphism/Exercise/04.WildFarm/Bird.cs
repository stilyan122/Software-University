using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        private double wingSize;
        public double WingSize { get; set; }
        public Bird(string name,double weight,int food,double wing)
            :base(name,weight,food)
        {
            this.WingSize = wing;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]".ToString();
        }
    }
}
