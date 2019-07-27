using CodingChallenge.Data.Classes;
using NUnit.Framework;
using System.Collections.Generic;
using CodingChallenge.Data.Localizacion;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                GeometricShape.Print(new List<GeometricShape>(), Language.Es));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                GeometricShape.Print(new List<GeometricShape>(), Language.En));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<GeometricShape> { new Square(5) };

            var resumen = GeometricShape.Print(cuadrados, Language.Es);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 Formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<GeometricShape>
            {
                new Square(5),
                new Square(1),
                new Square(3)
            };

            var resumen = GeometricShape.Print(cuadrados, Language.En);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 Shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<GeometricShape>
            {
                new Square(5),
                new Circle(3),
                new EquilatereTriangle(4),
                new Square(2),
                new EquilatereTriangle(9),
                new Circle(2.75m),
                new EquilatereTriangle(4.2m)
            };

            var resumen = GeometricShape.Print(formas, Language.En);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 Shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<GeometricShape>
            {
                new Square(5),
                new Circle(3),
                new EquilatereTriangle(4),
                new Square(2),
                new EquilatereTriangle(9),
                new Circle(2.75m),
                new EquilatereTriangle(4.2m)
            };

            var resumen = GeometricShape.Print(formas, Language.Es);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 Formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<GeometricShape>
            {
                new Square(5),
                new Circle(3),
                new EquilatereTriangle(4),
                new Square(2),
                new EquilatereTriangle(9),
                new Circle(2.75m),
                new EquilatereTriangle(4.2m)
            };

            var resumen = GeometricShape.Print(formas, Language.It);

            Assert.AreEqual(
                "<h1>Rapporto forma</h1>2 Quadrato | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>TOTALE:<br/>7 Forme Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTrapecioEnCastellano()
        {
            var formas = new List<GeometricShape>
            {
                new IsoscelesTrapezium(6.71m, 3, 9)
            };

            var resumen = GeometricShape.Print(formas, Language.Es);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Trapecio | Area 36,01 | Perimetro 25,42 <br/>TOTAL:<br/>1 Formas Perimetro 25,42 Area 36,01",
                resumen);
        }
    }
}
