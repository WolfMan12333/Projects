using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zapytaniaLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] slowa = { "czereśnia", "jabłko", "borówka", "wiśnia", "jagoda", "gruszka", "śliwka", "malina" };

            //metody rozszerzeń LINQ
            //min i max słowa w lambda
            string minslowo = slowa.Min();
            string maxslowo = slowa.Max();

            Console.WriteLine("Najkrotsze slowo: " + minslowo + " najdluzsze slowo: " + maxslowo + "\n");

            //średnia długość słów
            int sredniadlg = (int)slowa.Average(w => w.Length);
            Console.WriteLine("Srednia dlugosc slow: {0}", sredniadlg);

            //suma słów
            int suma = slowa.Sum(w => w.Length);
            Console.WriteLine("Suma slow: {0}", suma);
            Console.WriteLine("\n");

            //Zapytania LINQ
            //Słowa o długości większej niż 6 posortowane alfabetycznie
            var w6 = from owoc in slowa
                     where owoc.Length > 6
                     orderby owoc
                     select owoc;

            Console.WriteLine("Owoce posortowane alfabetyczne: ");
            foreach (var owoc in w6)
                Console.WriteLine(owoc);

            Console.WriteLine("\n");

            //Słowa o długości większej niż 6 liter posortowane według ich długości
            var w62 = from owoc in slowa
                      where owoc.Length > 6
                      orderby owoc.Length
                      select owoc;

            Console.WriteLine("Owoce posortowane wedlug dlugosci: ");
            foreach (var owoc in w62)
                Console.WriteLine(owoc);

            Console.WriteLine("\n");

            //Słowa kończące się na "a" posortowane według ostatniej litery
            var a = from owoc in slowa
                    where owoc.EndsWith("a")
                    orderby owoc.Last()
                    select owoc;

            foreach (var owoc in a)
                Console.WriteLine(owoc);

            Console.WriteLine("\n");

            //zwraca długość poszczególnych słów posortowane według alfabetycznej kolejności tych słów
            var s = from owoc in slowa
                    orderby owoc
                    select owoc.Length;

            Console.WriteLine("Kolejne poszczegolnych posortowanych alfabetycznie slow: ");
            foreach (var owoc in s)
                Console.WriteLine(owoc);

            Console.WriteLine("\n");

            //tylko dla słów zawierających "o"
            var o = from owoc in slowa
                    where owoc.Equals("o")
                    orderby owoc
                    select owoc;

            Console.WriteLine("Kolejna posortowana grupa:");
            foreach (var owoc in slowa)
                Console.WriteLine(owoc);

            Console.WriteLine("\n");

            //zwraca slowa z zmienionymi literami na duże
            var duze = from owoc in slowa
                       select owoc;

            Console.WriteLine("Ze zmienionymi literami małe na duże: ");
            foreach (var owoc in slowa)
                Console.WriteLine(owoc.ToUpper());

            Console.ReadKey();
        }
    }
}
