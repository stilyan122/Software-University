using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        private string model;
        private string color;
        public string Model { get; set; }
        public string Color { get ; set; }

        public Seat(string model,string color)
        {
            this.Model = model;
            this.Color = color;
        }
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
            output.AppendLine($"{this.Color} Seat {this.Model}");
            output.AppendLine(this.Start());
            output.AppendLine(this.Stop());
            return output.ToString().TrimEnd();
        }
    }
}
