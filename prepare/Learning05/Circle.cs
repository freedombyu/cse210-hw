public class Circle : Shape
{
    private string _Color;
    private double _Radius;

    public Circle(string color, double radius) 
    {
        _Color = color;
        _Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * _Radius * _Radius;
    }
}
