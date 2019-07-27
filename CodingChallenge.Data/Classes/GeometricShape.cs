/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using Castle.Core.Internal;
using CodingChallenge.Data.Localizacion;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public abstract class GeometricShape
    {
        private class Results
        {
            public decimal Area { get; set; }

            public decimal Perimeter { get; set; }

            public int Amount { get; set; }
        }

        private static LocalizationProvider _localizationProvider => LocalizationProvider.Instance;
        protected readonly decimal _side;

        protected GeometricShape(decimal width)
        {
            _side = width;
        }

        public abstract decimal CalculateArea();

        public abstract decimal CalculatePerimeter();

        public static string Print(List<GeometricShape> shapes, Language language)
        {
            var sb = new StringBuilder();

            if (!shapes.Any())
            {
                sb.Append(
                    _localizationProvider.GetTranslation(
                        "EmptyShapeList", language));
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append(
                    _localizationProvider.GetTranslation(
                        "ShapesReport", language));

                var shapeResults = new Dictionary<string, Results>();
                shapes.ForEach(shape => FillResultsDictionary(shape, shapeResults));
                shapeResults.ForEach(entry => sb.Append(CreateLine(entry.Key, entry.Value.Amount, entry.Value.Area, entry.Value.Perimeter, language)));

                // FOOTER
                sb.Append(_localizationProvider.GetTranslation("Total", language));
                sb.Append($"{shapeResults.Sum(entry => entry.Value.Amount)} {_localizationProvider.GetTranslation("Shapes", language)} ");
                sb.Append($"{_localizationProvider.GetTranslation("Perimeter", language)} {shapeResults.Sum(entry => entry.Value.Perimeter):#.##} ");
                sb.Append($"{_localizationProvider.GetTranslation("Area", language)} {shapeResults.Sum(entry => entry.Value.Area):#.##}");
            }

            return sb.ToString();
        }

        private static void FillResultsDictionary(GeometricShape shape, IDictionary<string, Results> shapeResults)
        {
            var key = shape.GetType().Name;
            if (!shapeResults.ContainsKey(key))
            {
                shapeResults[key] = new Results
                {
                    Amount = 1,
                    Area = shape.CalculateArea(),
                    Perimeter = shape.CalculatePerimeter()
                };
            }
            else
            {
                shapeResults[key].Amount++;
                shapeResults[key].Perimeter += shape.CalculatePerimeter();
                shapeResults[key].Area += shape.CalculateArea();
            }
        }

        private static string CreateLine(string shapeType, int amount, decimal area, decimal perimeter, Language language)
        {
            if (amount <= 0) return string.Empty;
            return $"{amount} " +
                   $"{_localizationProvider.GetTranslation(amount == 1 ? shapeType : shapeType + "s", language)} | " +
                   $"{_localizationProvider.GetTranslation("Area", language)} {area:#.##} | " +
                   $"{_localizationProvider.GetTranslation("Perimeter", language)} {perimeter:#.##} <br/>";
        }
    }
}
