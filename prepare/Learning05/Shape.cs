public abstract class Shape
{
    // Shape class, the base class for all shapes
    class _Shape
    {
        private string _Color;

        public _Shape(string color)
        {
            _Color = color;
        }

        // Method to compute area, to be overridden by derived classes
        public virtual double GetArea()
        {
            return 0;
        }
    }
}
