using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helion;

namespace UlamekTestyJednostkowe
{
    [TestClass]
    public class UlamekTesty
    {
        [TestMethod]
        public void TestKonstruktoraIWlasnosci()
        {
            //przgotowania (assert)
            int licznik = 1;
            int mianownik = 2;

            //działanie (act)
            Ulamek u = new Ulamek(licznik, mianownik);

            //weryfikacja (assert)
            Assert.AreEqual(licznik, u.Licznik, "Niezgodność w liczniku");
            Assert.AreEqual(mianownik, u.Mianownik, "Niezgodnosc w mianowniku");
        }

        [TestMethod]
        public void TestKonstruktora()
        {
            //przygotowania (assert)
            int licznik = 1;
            int mianownik = 2;

            //działanie (act)
            Ulamek u = new Ulamek(licznik, mianownik);

            //weryfikacja (assert)
            PrivateObject po = new PrivateObject(u);
            int u_licznik = (int)po.GetField("licznik");
            int u_mianownik = (int)po.GetField("mianownik");
            Assert.AreEqual(licznik, u_licznik, "Niezgodnosc w liczniku");
            Assert.AreEqual(mianownik, u_mianownik, "Niezgodnosc w mianowniku");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestKonstruktoraWyjatek()
        {
            Ulamek u = new Ulamek(1, 0);
        }

        //testowanie metod dla przykładowych wartości parametrów
        [TestMethod]
        public void TestPolaStatycznegoPolowa()
        {
            Ulamek uP = Ulamek.Polowa;
            Assert.AreEqual(1, uP.Licznik);
            Assert.AreEqual(2, uP.Mianownik);
        }

        [TestMethod]
        public void TestMetodyUprosc()
        {
            Ulamek u = new Ulamek(4, 2);

            u.Uprosc();

            Assert.AreEqual(-2, u.Licznik);
            Assert.AreEqual(1, u.Mianownik);
        }

        [TestMethod]
        public void TestOperatorow()
        {
            Ulamek a = Ulamek.Polowa;
            Ulamek b = Ulamek.Cwierc;

            Assert.AreEqual(new Ulamek(3, 4), a + b, "Niepowodzenie przy dodawaniu");
            Assert.AreEqual(Ulamek.Cwierc, a - b, "Niepowodzenie przy odejmowaniu");
            Assert.AreEqual(new Ulamek(1, 8), a * b, "Niepowodzenie przy mnozeniu");
            Assert.AreEqual(new Ulamek(2), a / b, "Niepowodzenie przy dzieleniu");
        }

        Random r = new Random();

        private int losujeLiczbeCalkowita(int? maksymalnaBezwzglednaWartosc = null)
        {
            if (!maksymalnaBezwzglednaWartosc.HasValue)
                return r.Next(int.MinValue, int.MaxValue);
            else
            {
                maksymalnaBezwzglednaWartosc = Math.Abs(maksymalnaBezwzglednaWartosc.Value);
                return r.Next(-maksymalnaBezwzglednaWartosc.Value, maksymalnaBezwzglednaWartosc.Value);
            }
        }

        private int losujLiczbeCalkowitaRoznaOdZera(int? maksymalnaBezwzglednaWartosc = null)
        {
            int wartosc;
            do
            {
                wartosc = losujeLiczbeCalkowita(maksymalnaBezwzglednaWartosc);
            } while (wartosc == 0);
            return wartosc;
        }

        [TestMethod]
        public void TestSortowania()
        {
            Ulamek[] tablica = new Ulamek[100];
            for (int i = 0; i < tablica.Length; i++)
                tablica[i] = new Ulamek(losujeLiczbeCalkowita(), losujLiczbeCalkowitaRoznaOdZera());

            Array.Sort(tablica);

            bool tablicaJestPosortowanaRosnaca = true;
            for (int i = 0; i < tablica.Length - 1; i++)
                if (tablica[i] >= tablica[i + 1]) tablicaJestPosortowanaRosnaca = false;

            Assert.IsTrue(tablicaJestPosortowanaRosnaca);
        }

        //Testy zawierające elementy losowe mogą być powtarzane w jednej metodzie
        const int liczbaPowtorzen = 100;

        [TestMethod]
        public void TestKonwersjiDoDouble()
        {
            for (int i = 0; i < liczbaPowtorzen; ++i)
            {
                int licznik = losujeLiczbeCalkowita();
                int mianownik = losujLiczbeCalkowitaRoznaOdZera();
                Ulamek u = new Ulamek(licznik, mianownik);

                double d = (double)u;

                Assert.AreEqual(licznik / (double)mianownik, d);
            }
        }

        [TestMethod]
        public void TestKonwersjiZInt()
        {
            for (int i = 0; i < liczbaPowtorzen; ++i)
            {
                int licznik = losujeLiczbeCalkowita();

                Ulamek u = licznik;

                Assert.AreEqual(licznik, u.Licznik);
                Assert.AreEqual(1, u.Mianownik);
            }
        }

        [TestMethod]
        public void TestMetodyUprosc_Losowy()
        {
            for (int i = 0; i < liczbaPowtorzen; ++i)
            {
                Ulamek u = new Ulamek(losujeLiczbeCalkowita(), losujLiczbeCalkowitaRoznaOdZera());

                Ulamek kopia = u;   //kopiowanie

                u.Uprosc();

                Assert.IsTrue(u.Mianownik > 0);
                Assert.AreEqual(kopia.ToDouble(), u.ToDouble());
            }
        }

        //Uwzględnienie bezpiecznego zakresu
        [TestMethod]
        public void TestOperatorow_Losowy()
        {
            //ograniczenie maksymalnej wartosci
            int limit = (int)(Math.Sqrt(int.MaxValue / 2) - 1);

            //dopuszczalna różnica w wyniku
            const double dokladnosc = 1E-10;

            for (int i = 0; i < liczbaPowtorzen; ++i)
            {
                Ulamek a = new Ulamek(losujeLiczbeCalkowita(limit), losujLiczbeCalkowitaRoznaOdZera(limit));

                Ulamek b = new Ulamek(losujeLiczbeCalkowita(limit), losujLiczbeCalkowitaRoznaOdZera(limit));

                double suma = (a + b).ToDouble();
                double roznica = (a - b).ToDouble();
                double iloczyn = (a * b).ToDouble();
                double iloraz = (a / b).ToDouble();

                Assert.AreEqual(a.ToDouble() + b.ToDouble(), suma, dokladnosc, "Niepowodzenie przy dodawaniu");
                Assert.AreEqual(a.ToDouble() - b.ToDouble(), roznica, dokladnosc, "Niepowodzenie przy odejmowaniu");
                Assert.AreEqual(a.ToDouble() * b.ToDouble(), iloczyn, dokladnosc, "Niepowodzenie przy mnozeniu");
                Assert.AreEqual(a.ToDouble() / b.ToDouble(), iloraz, dokladnosc, "Niepowodzenie przy dzieleniu");
            }
        }
    }
}
