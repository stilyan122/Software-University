using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double grams;
        private double weight;
        private double modifier1;
        private double modifier2;
        public Dough(string flourType,string bakingTechnique,double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        private string FlourType { 
            get
            {
                return flourType;
            }
            set
            {
                switch (value.ToLower())
                {
                    case "white":
                        modifier1 = 1.5;
                        break;
                    case "wholegrain":
                        modifier1 = 1.0;
                        break;
                    default:
                        throw new Exception("Invalid type of dough.");
                }
                flourType = value;
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
                if (value<0||value>200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
        private string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            set
            {
                switch (value.ToLower())
                {
                    case "crispy":
                        modifier2 = 0.9;
                        break;
                    case "chewy":
                        modifier2 = 1.1;
                        break;
                    case "homemade":
                        modifier2 = 1.0;
                        break;
                    default:
                        throw new Exception("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        public double CaloriesPerGram
        {
            get 
            {
                return 2 * weight * modifier1 * modifier2;
            }
        }
    }
}
