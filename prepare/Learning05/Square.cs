class Square : Shape
{
    private string _Color;
    private double _Side;

    public Square(string color, double side)
    {
        _Color = color;
        _Side = side;
    }

    public override double GetArea()
    {
        return _Side * _Side;
    }
}