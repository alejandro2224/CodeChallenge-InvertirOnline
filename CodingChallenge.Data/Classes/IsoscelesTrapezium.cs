using System;

namespace CodingChallenge.Data.Classes
{
    public class IsoscelesTrapezium : GeometricShape
    {
        private readonly decimal _firstBaseValue;
        private readonly decimal _secondBaseValue;

        public IsoscelesTrapezium(decimal diagonals,
            decimal firstBaseValue,
            decimal secondBaseValue) : base(diagonals)
        {
            _firstBaseValue = firstBaseValue;
            _secondBaseValue = secondBaseValue;
        }

        public override decimal CalculateArea()
        {
            var calcFirstSide = (_firstBaseValue + _secondBaseValue) / 2;
            var diagonal = _side * _side;
            var baseDiff = _firstBaseValue > _secondBaseValue
                ? _firstBaseValue - _secondBaseValue
                : _secondBaseValue - _firstBaseValue;

            var aux = (decimal)Math.Pow(Convert.ToDouble(baseDiff / 2), 2);
            var calcSecondSide = (decimal)Math.Sqrt(Convert.ToDouble(diagonal - aux));
            return calcFirstSide * calcSecondSide;
        }


        public override decimal CalculatePerimeter() => _firstBaseValue + _secondBaseValue + _side * 2;
    }
}
