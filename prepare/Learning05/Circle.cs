public class Circle : Shape
{
    private double _radius = 5;
    private double _pi = 3.14;
    public override double GetArea()
    {
        return _pi * _radius * _radius;
    }
}