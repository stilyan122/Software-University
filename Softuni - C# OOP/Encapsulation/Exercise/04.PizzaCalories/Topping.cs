using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double modifier;
        private double weight;
        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        private string Type
        {
            get
            {
                return type;
            }
            set
            {
                switch (value.ToLower())
                {
                    case "meat":
                        modifier = 1.2;
                        break;
                    case "veggies":
                        modifier = 0.8;
                        break;
                    case "cheese":
                        modifier = 1.1;
                        break;
                    case "sauce":
                        modifier = 0.9;
                        break;
                    default:
                        throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }
        public double CaloriesPerGram
        { 
            get 
            {
                return Weight * modifier * 2;
            }
        }
        private double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if(value<0||value>50)
                {
                    throw new Exception($"{this.Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
    }
}
