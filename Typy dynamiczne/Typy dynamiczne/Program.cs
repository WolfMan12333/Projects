using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typy_dynamiczne
{
    class Klasa
    {
        public delegate void Callback(object sender, DateTime czasZakonczeniaMetody);

        public Callback DMZ;
        public event Callback ZMZ;

        public void Metoda()
        {
            Console.WriteLine("Metoda - poczatek");
            //tu długie działanie metody
            Console.WriteLine("Metoda - tuz przed koncem");
            if (DMZ != null)
                DMZ(this, DateTime.Now);
            if (ZMZ != null)
                ZMZ(this, DateTime.Now);

            Console.WriteLine("Metoda - koniec.");
        }
    }

    class Program
    {
        static dynamic obiekt = 1; //pole zainicjowane obiektem typu int

        enum Typ { Int, Long, String, Float, Double, DivideByZeroException, Pole, InstancjaKlasy };

        dynamic Obiekt //Właściwość
        {
            get
            {
                return zwrocObiekt();
            }
            set
            {
                obiekt = value;
            }
        }

        static dynamic zwrocObiekt(Typ ktoryTyp = Typ.Int) //Wartość zwracana przez metodę
        {
            dynamic wartosc;
            switch (ktoryTyp)
            {
                case Typ.Int: wartosc = 5; break;
                case Typ.Long: wartosc = 5L; break;
                case Typ.String: wartosc = "Helion"; break;
                case Typ.Float: wartosc = 1.0f; break;
                case Typ.Double: wartosc = 1.0; break;
                case Typ.DivideByZeroException: wartosc = new DivideByZeroException(); break;
                case Typ.Pole: wartosc = obiekt; break;
                case Typ.InstancjaKlasy: wartosc = new Klasa(); break;
                default: wartosc = null; break;
            }
            return wartosc;
        }

        static void Main(string[] args)
        {
            for (Typ typ = Typ.Int; typ <= Typ.InstancjaKlasy; ++typ)
            {
                try
                {
                    dynamic o = zwrocObiekt(typ);

                    Console.WriteLine("Obiekt: " + o.ToString() + ", typ: " + o.GetType().FullName);
                    o.Metoda(); //tu pojawi się wyjątek
                }
                catch (Exception exc)
                {
                    ConsoleColor biezacyKolor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Blad: " + exc.Message);
                    Console.ForegroundColor = biezacyKolor;
                }
            }

            Console.ReadKey();
        }
    }
}
