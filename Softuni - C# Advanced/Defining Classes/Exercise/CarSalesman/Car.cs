using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;
        public Car(string model,Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{this.Model}:");
            output.AppendLine($" {this.Engine.Model}:");
            output.AppendLine($"  Power: {this.Engine.Power}");
            if(this.Engine.Displacement!=default)
            output.AppendLine($"  Displacement: {this.Engine.Displacement}");
            else
            output.AppendLine($"  Displacement: n/a");
            if(this.Engine.Efficiency!=default)
            output.AppendLine($"  Efficiency: {this.Engine.Efficiency}");
            else
            output.AppendLine($"  Efficiency: n/a");
            if (this.Weight != default)
            output.AppendLine($" Weight: {this.Weight}");
            else
            output.AppendLine($" Weight: n/a");
            if (this.Color != default)
                output.AppendLine($" Color: {this.Color}");
            else
                output.AppendLine($" Color: n/a");
            return output.ToString().TrimEnd();
        }
    }
}
