using System;

namespace CodingChallenge.Data.Classes
{
    public class Circle : GeometricShape
    {
        public Circle(decimal width) : base(width)
        {
        }

        public override decimal CalculateArea() => (decimal)Math.PI * (_side / 2) * (_side / 2);

        public override decimal CalculatePerimeter() => (decimal)Math.PI * _side;
    }
}