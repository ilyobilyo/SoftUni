using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"   Power: {Engine.Power}");

            if (Engine.Displacement == null)
            {
                sb.AppendLine($"   Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"   Displacement: {Engine.Displacement}");
            }

            if (Engine.Efficiency == null)
            {
                sb.AppendLine($"   Efficiency: n/a");
            }
            else
            {
                sb.AppendLine($"   Efficiency: {Engine.Efficiency}");
            }

            if (Weight == null)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {Weight}");
            }

            if (Color == null)
            {
                sb.Append($"  Color: n/a");
            }
            else
            {
                sb.Append($"  Color: {Color}");
            }

            return sb.ToString();
        }
    }
}
