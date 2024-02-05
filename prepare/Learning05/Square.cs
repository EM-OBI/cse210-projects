public class Square : Shape
{
    private double _side = 10;
    public override double GetArea()
    {
        return _side * _side;
    }
}