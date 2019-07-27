namespace CodingChallenge.Data.Classes
{
    public class Square : GeometricShape
    {
        public Square(decimal width) : base(width)
        {
        }

        public override decimal CalculateArea() => _side * _side;

        public override decimal CalculatePerimeter() => _side * 4;
    }
}