using System;

namespace StructComplexNumber
{
    public struct LiczbaZespolona
    {
        //Konstruktor
        public LiczbaZespolona(double real, double imag)
            : this()
        {
            Real = real;
            Imag = imag;
        }

        //Właściwości auto-implemented
        public double Real { get; set; }
        public double Imag { get; set; }

        //stałe wartośći
        public static readonly LiczbaZespolona Zero = new LiczbaZespolona(0, 0);
        public static readonly LiczbaZespolona Jeden = new LiczbaZespolona(1, 0);
        public static readonly LiczbaZespolona I = new LiczbaZespolona(0, 1);

        //metody
        //sprzężenie zespolone
        public string Conj()
        {
            return "(" + Real.ToString() + " - " + Imag.ToString() + "i)";
        }

        public override string ToString()
        {
            string wynik = "(" + Real.ToString() + " + " + Imag.ToString() + "i)";

            if (Imag.ToString() == "1")
                wynik = "(" + Real.ToString() + " + " + "i)";
            if (Imag.ToString() == "0")
                wynik = Real.ToString();

            return wynik;
        }

        public double Moduł()
        {
            double wynik = Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imag, 2));
            return wynik;
        }

        #region Operatory
        //operacje arytmetyczne
        public static LiczbaZespolona operator +(LiczbaZespolona z1, LiczbaZespolona z2)
        {
            LiczbaZespolona wynik = new LiczbaZespolona(z1.Real + z2.Real, z1.Imag + z2.Imag);
            return wynik;
        }

        public static LiczbaZespolona operator -(LiczbaZespolona z1, LiczbaZespolona z2)
        {
            LiczbaZespolona wynik = new LiczbaZespolona(z1.Real - z2.Real, z1.Imag - z2.Imag);
            return wynik;
        }

        public static LiczbaZespolona operator *(LiczbaZespolona z1, LiczbaZespolona z2)
        {
            LiczbaZespolona wynik = new LiczbaZespolona((z1.Real * z2.Real - z1.Imag * z2.Imag), (z1.Imag * z2.Real + z1.Real * z2.Imag));
            return wynik;
        }

        public static LiczbaZespolona operator /(LiczbaZespolona z1, LiczbaZespolona z2)
        {
            LiczbaZespolona wynik = new LiczbaZespolona(((z1.Real * z2.Real) + (z1.Imag * z2.Imag)) / (z2.Real + z2.Imag), ((z1.Imag * z2.Real) - (z1.Real * z2.Imag)) / (z2.Real + z2.Imag));
            return wynik;
        }
        #endregion
    }
}
