using System;

namespace Shape
{
    abstract class _Shape
    {
        private string _Color;

        public _Shape(string color)
        {
            _Color = color;
        }

        // Method to compute area, to be overridden by derived classes
        public abstract double GetArea();
    
    }
}
