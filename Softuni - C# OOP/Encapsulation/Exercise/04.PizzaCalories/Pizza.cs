using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private Dough dough;
        private List<Topping> toppings;
        private string name;
        public Pizza(string name,Dough dough)
        {
            this.Dough = dough;
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        public Dough Dough { 
            set 
            {
                dough = value;
            } }
        private List<Topping> Toppings { get; set; }
        public string Name {
            get
            {
                return name;
            } 
            private set 
            {
                if (string.IsNullOrWhiteSpace(value)||value.Length>15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            } 
        }
        public int Count {
            get
            {
                return this.Toppings.Count;
            }
        }
        public double Calories { 
            get
            {
                double total = 0.0;
                foreach (var item in Toppings)
                {
                    total += item.CaloriesPerGram;
                }
                total += dough.CaloriesPerGram;
                return total;
            } 
        }
        public void AddTopping(Topping topping)
        {
            if (Toppings.Count > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            else
            {
                this.Toppings.Add(topping);
            }
        }
    }
}
