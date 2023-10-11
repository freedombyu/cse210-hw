public class Rectangle : Shape
{
    private string _Color;
    private double _Length;
    private double _Width;

    public Rectangle(string color, double length, double width)
    {
        _Color = color;
        _Length = length;
        _Width = width;
    }

    public double CalculateArea()
    {
        return _Length * _Width;
    }
}