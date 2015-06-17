using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructComplexNumber;

namespace ComplexNumberTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDodawania()
        {
            LiczbaZespolona z1 = new LiczbaZespolona(1, 2);
            LiczbaZespolona z2 = new LiczbaZespolona(2, 3);
            LiczbaZespolona z3 = new LiczbaZespolona(4, 6);
            LiczbaZespolona z4 = new LiczbaZespolona(5, 1);
            LiczbaZespolona z5 = new LiczbaZespolona(20, 7);
            LiczbaZespolona z6 = new LiczbaZespolona(4, 14);

            Assert.AreEqual(new LiczbaZespolona(3, 5), z1 + z2, "Niepowodzenie przy dodawaniu");
            Assert.AreEqual(new LiczbaZespolona(9, 7), z3 + z4, "Niepowodzenie przy dodawaniu");
            Assert.AreEqual(new LiczbaZespolona(24, 21), z5 + z6, "Niepowodzenie przy dodawaniu");
        }

        [TestMethod]
        public void TestowanieOdejmowania()
        {
            LiczbaZespolona z1 = new LiczbaZespolona(2, 1);
            LiczbaZespolona z2 = new LiczbaZespolona(6, 3);
            LiczbaZespolona z3 = new LiczbaZespolona(4, 6);
            LiczbaZespolona z4 = new LiczbaZespolona(3, 2);
            LiczbaZespolona z5 = new LiczbaZespolona(2, 3);
            LiczbaZespolona z6 = new LiczbaZespolona(1, 2);

            Assert.AreEqual(new LiczbaZespolona(-4, -2), z1 - z2, "Niepowodzenie przy odejmowaniu");
            Assert.AreEqual(new LiczbaZespolona(1, 4), z3 - z4, "Niepowodzenie przy odejmowaniu");
            Assert.AreEqual(new LiczbaZespolona(1, 1), z5 - z6, "Niepowodzenie przy odejmowaniu");
        }

        [TestMethod]
        public void TestowanieMnozenia()
        {
            LiczbaZespolona z1 = new LiczbaZespolona(1, 2);
            LiczbaZespolona z2 = new LiczbaZespolona(2, 3);
            LiczbaZespolona z3 = new LiczbaZespolona(4, 6);
            LiczbaZespolona z4 = new LiczbaZespolona(5, 1);
            LiczbaZespolona z5 = new LiczbaZespolona(20, 7);
            LiczbaZespolona z6 = new LiczbaZespolona(4, 14);

            Assert.AreEqual(new LiczbaZespolona(-4, 7), z1 * z2, "Niepowodzenie przy mnozeniu");
            Assert.AreEqual(new LiczbaZespolona(14, 34), z3 * z4, "Niepowodzenie przy mnozeniu");
            Assert.AreEqual(new LiczbaZespolona(-18, 308), z5 * z6, "Niepowodzenie przy mnozeniu");
        }

        [TestMethod]
        public void TestowanieDzielenia()
        {
            LiczbaZespolona z1 = new LiczbaZespolona(1, 2);
            LiczbaZespolona z2 = new LiczbaZespolona(2, 3);
            LiczbaZespolona z3 = new LiczbaZespolona(4, 6);
            LiczbaZespolona z4 = new LiczbaZespolona(5, 1);
            LiczbaZespolona z5 = new LiczbaZespolona(20, 7);
            LiczbaZespolona z6 = new LiczbaZespolona(4, 14);

            Assert.AreEqual(new LiczbaZespolona(1.6, 0.2), z1 / z2, "Niepowodzenie przy dzieleniu");
            Assert.AreEqual(new LiczbaZespolona(4.33333333333333, 4.33333333333333), z3 / z4, "Niepowodzenie przy dzieleniu");
            Assert.AreEqual(new LiczbaZespolona(9.88888888888889, -14), z5 / z6, "Niepowodzenie przy dzieleniu");
        }
    }
}
