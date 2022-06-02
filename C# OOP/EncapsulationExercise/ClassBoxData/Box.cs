using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        private double Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                else
                {
                    length = value;
                }
            }
        }
        private double Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                else
                {
                    width = value;
                }
            }
        }
        private double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                else
                {
                    height = value;
                }
            }
        }

        private double SurfaceArea()
        {
            double result = (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);

            return result;
        }

        private double LateralSurfaceArea()
        {
            double result = (2 * Length * Height) + (2 * Width * Height);

            return result;
        }

        private double Volume()
        {
            double result = Length * Width * Height;

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {Volume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
