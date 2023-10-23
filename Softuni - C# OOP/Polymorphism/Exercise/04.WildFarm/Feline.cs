using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Feline : Mammal
    {
        private string breed;
        public Feline(string name, double weight, int foodEaten,string region, string breed)
            :base(name,weight,foodEaten,region)
        {
            this.Breed = breed;
        }
        public string Breed { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]".ToString();
        }
    }
}
