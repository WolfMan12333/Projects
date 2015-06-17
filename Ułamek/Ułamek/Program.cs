using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Helion;
using Helion2;

namespace Ułamek
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

            Ulamek u1 = new Ulamek { Licznik = 1, Mianownik = 2 };
            Console.WriteLine(u1.ToString());

            Ulamek u3 = new Ulamek();
            u3.Licznik = 1;
            u3.Mianownik = 2;

            Ulamek k = new Ulamek(1, 2);

            Ulamek a = Ulamek.Polowa;
            Ulamek b = Ulamek.Cwierc;

            Console.WriteLine((a + b).ToString());
            Console.WriteLine((a - b).ToString());
            Console.WriteLine((a * b).ToString());
            Console.WriteLine((a / b).ToString());

            double r = (double)Ulamek.Polowa;
            Console.WriteLine(r.ToString());
            Ulamek c = 2;
            Console.WriteLine(c.ToString());

            Ulamek[] tablica = new Ulamek[10];
            for (int i = 0; i < tablica.Length; ++i) tablica[i] = new Ulamek(1, i + 1);

            Console.WriteLine("Przed sortowaniem:");
            foreach (Ulamek u4 in tablica)
                Console.WriteLine(u4.ToString() + "=" + u4.ToDouble().ToString());
            
            
            try
            {
                Array.Sort(tablica);
            }
            catch (Exception exc)
            {
                ConsoleColor bieżącyKolor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exc.Message);
                Console.ForegroundColor = bieżącyKolor;
            }

            Console.WriteLine("Po sortowaniu:");
            foreach (Ulamek u5 in tablica)
                Console.WriteLine(u5.ToString() + "=" + u5.ToDouble().ToString());

            Console.ReadKey();
        }
    }
}
