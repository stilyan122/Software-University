using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int battery;
        public Tesla(string model, string color,int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }
        public string Model { get; set; }
        public string Color { get ; set; }
        public int Battery { get ; set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{this.Color} Tesla {this.Model} with {this.Battery} Batteries");
            output.AppendLine(this.Start());
            output.AppendLine(this.Stop());
            return output.ToString().TrimEnd();
        }
    }
}
