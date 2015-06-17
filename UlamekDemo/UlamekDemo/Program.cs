using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helion;

namespace UlamekDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Ulamek u2 = new Ulamek(2, 1);
            Ulamek u0 = Ulamek.Zero;
            Ulamek uP = Ulamek.Polowa;
            Console.WriteLine(uP.ToString());

            Console.WriteLine(Ulamek.Info());

            Ulamek u = new Ulamek(4, -2);
            u.Uprosc();
            Console.WriteLine(u.ToString());

            Ulamek u3 = new Ulamek { Licznik = 1, Mianownik = 2 };
            Console.WriteLine(u3.ToString());

            Ulamek a = Ulamek.Polowa;
            Ulamek b = Ulamek.Cwierc;

            Console.WriteLine((a + b).ToString());
            Console.WriteLine((a - b).ToString());
            Console.WriteLine((a * b).ToString());
            Console.WriteLine((a / b).ToString());

            //test operatorów konwersji
            double r = (double)Ulamek.Polowa;
            Console.WriteLine(r.ToString());
            Ulamek c = 2;
            Console.WriteLine(c.ToString());

            //przykład definowania tablicy zawierającej ułamki
            Ulamek[] tablica = new Ulamek[10];
            for (int i = 0; i < tablica.Length; i++) tablica[i] = new Ulamek(1, i + 1);

            Console.WriteLine("Przed sortowaniem:");
            foreach (Ulamek us in tablica)
                Console.WriteLine(us.ToString() + "=" + us.ToDouble().ToString());

            //sortowanie tablicy ułamków
            try
            {
                Array.Sort(tablica);
            }
            catch(Exception exc)
            {
                ConsoleColor biezacyKolor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exc.Message);
                Console.ForegroundColor = biezacyKolor;
            }

            Console.WriteLine("Po sortowaniu:");
            foreach (Ulamek us in tablica)
                Console.WriteLine(us.ToString() + "=" + us.ToDouble().ToString());

            Console.ReadKey();
        }
    }
}
