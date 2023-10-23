using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;
        public Mammal(string name,double weight, int foodEaten,string region)
            :base(name,weight,foodEaten)
        {
            this.LivingRegion = region;
        }
        public string LivingRegion { get; set; }
    }
}
