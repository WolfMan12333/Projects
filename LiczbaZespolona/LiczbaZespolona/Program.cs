using System;
using StructComplexNumber;

namespace LiczbaZespolona2
{
    class Program
    {
        static void Main(string[] args)
        {
            //liczby do testów numer jeden
            LiczbaZespolona z1 = new LiczbaZespolona(1, 2);
            LiczbaZespolona z2 = new LiczbaZespolona(2, 3);

            //liczby do testów numer dwa
            LiczbaZespolona z3 = new LiczbaZespolona(4, 6);
            LiczbaZespolona z4 = new LiczbaZespolona(5, 1);

            //liczby do testów numer trzy
            LiczbaZespolona z5 = new LiczbaZespolona(20, 7);
            LiczbaZespolona z6 = new LiczbaZespolona(4, 14);

            //stałe
            LiczbaZespolona zero = LiczbaZespolona.Zero;
            LiczbaZespolona jeden = LiczbaZespolona.Jeden;
            LiczbaZespolona i = LiczbaZespolona.I;

            //Wypisanie liczb do testów
            //numer jeden:
            Console.WriteLine("Wypisanie liczb do testów\nnumer jeden:");
            Console.WriteLine(z1.ToString());
            Console.WriteLine(z2.ToString());

            //numer dwa:
            Console.WriteLine("\n\nnumer dwa:");
            Console.WriteLine(z3.ToString());
            Console.WriteLine(z4.ToString());

            //numer trzy:
            Console.WriteLine("\n\nnumer trzy:");
            Console.WriteLine(z5.ToString());
            Console.WriteLine(z6.ToString());

            //stałe:
            Console.WriteLine("\n\nstałe:");
            Console.WriteLine(zero.ToString());
            Console.WriteLine(jeden.ToString());
            Console.WriteLine(i.ToString());

            //moduł z liczby zespolonej
            Console.WriteLine("\nmodul z liczby zespolonej:");
            var n = z1.Moduł();
            Console.WriteLine(n.ToString());
            n = z2.Moduł();
            Console.WriteLine(n.ToString());
            n = z3.Moduł();
            Console.WriteLine(n.ToString());
            n = z4.Moduł();
            Console.WriteLine(n.ToString());
            n = z5.Moduł();
            Console.WriteLine(n.ToString());
            n = z6.Moduł();
            Console.WriteLine(n.ToString());
            n = zero.Moduł();
            Console.WriteLine(n.ToString());
            n = jeden.Moduł();
            Console.WriteLine(n.ToString());
            n = i.Moduł();
            Console.WriteLine(n.ToString());

            //sprzężenie liczby zespolonej
            Console.WriteLine("\nSprzezenia liczb zespolonych:");
            var sn = z1.Conj();
            Console.WriteLine(sn.ToString());
            sn = z2.Conj();
            Console.WriteLine(sn.ToString());
            sn = z3.Conj();
            Console.WriteLine(sn.ToString());
            sn = z4.Conj();
            Console.WriteLine(sn.ToString());
            sn = z5.Conj();
            Console.WriteLine(sn.ToString());
            sn = z6.Conj();
            Console.WriteLine(sn.ToString());
            sn = zero.Conj();
            Console.WriteLine(sn.ToString());
            sn = jeden.Conj();
            Console.WriteLine(sn.ToString());
            sn = i.Conj();
            Console.WriteLine(sn.ToString());

            //dodawanie
            Console.WriteLine("\nDodawanie:");
            var v = z1 + z2;
            Console.WriteLine(v);
            v = z3 + z4;
            Console.WriteLine(v);
            v = z5 + z6;
            Console.WriteLine(v);

            //odejmowanie
            Console.WriteLine("\nOdejmowanie:");
            var od = z1 - z2;
            Console.WriteLine(od);
            od = z3 - z4;
            Console.WriteLine(od);
            od = z5 - z6;
            Console.WriteLine(od);

            //mnożenie
            Console.WriteLine("\nMnozenie:");
            var mn = z1 * z2;
            Console.WriteLine(mn);
            mn = z3 * z4;
            Console.WriteLine(mn);
            mn = z5 * z6;
            Console.WriteLine(mn);

            //dzielenie
            Console.WriteLine("\nDzielenie:");
            var dz = z1 / z2;
            Console.WriteLine(dz);
            dz = z3 / z4;
            Console.WriteLine(dz);
            dz = z5 / z6;
            Console.WriteLine(dz);

            Console.ReadKey();
        }
    }
}
