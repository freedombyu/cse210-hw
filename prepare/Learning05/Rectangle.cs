public class Rectangle : Shape
{
    private double _Length;
    private double _Width;

    public Rectangle(string color, double length, double width) : base(color)
    {
        _Length = length;
        _Width = width;
    }

    public override double GetArea()
    {
        return _Length * _Width;
    }
}