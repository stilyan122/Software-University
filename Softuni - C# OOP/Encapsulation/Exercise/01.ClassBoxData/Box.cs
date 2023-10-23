using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Box
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length,double width,double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length {
            get
            {
                return length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }
        public double Width
        {
            get
            {
                return width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }

        public double SurfaceArea()
        {
            double area = 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
            return area;
        }
        public double LateralSurfaceArea()
        {
            double area = 2 * Length * Height + 2 * Width * Height;
            return area;
        }
        public double Volume()
        {
            double area = Length * Height * Width;
            return area;
        }
    }
}
