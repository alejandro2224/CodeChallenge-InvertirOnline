using System;

namespace CodingChallenge.Data.Classes
{
    public class EquilatereTriangle : GeometricShape
    {
        public EquilatereTriangle(decimal width) : base(width)
        {
        }

        public override decimal CalculateArea() => ((decimal)Math.Sqrt(3) / 4) * _side * _side;

        public override decimal CalculatePerimeter() => _side * 3;
    }
}