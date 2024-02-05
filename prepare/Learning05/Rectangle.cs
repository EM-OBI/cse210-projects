public class Rectangle : Shape
{
    private double _width = 5;
    private double _length = 30;
    public override double GetArea()
    {
        return _width * _length;
    }
}