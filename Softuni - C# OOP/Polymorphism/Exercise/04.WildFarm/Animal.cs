using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;
        public Animal(string name,double weight,int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }
        public abstract void AskForFood();
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
    }
}
