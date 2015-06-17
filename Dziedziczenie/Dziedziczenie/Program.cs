using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziedziczenie
{
    class Program
    {
        //Użycie interfejsu jako argumentu metody i parametru kolekcji
        static void WyświetlNumerTelefonu(IPosiadaTelefonStacjonarny telefon)
        {
            Console.WriteLine("Numer telefonu: " + telefon.NumerTelefonu);
        }

        static void Main(string[] args)
        {
            OsobaZameldowana jk = new OsobaZameldowana()
            {
                Imie = "Jan",
                Nazwisko = "Kowalski",
                Wiek = 42,
                AdresZameldowania = new Adres
                {
                    Miasto = "Torun",
                    Ulica = "Grudzidzka",
                    NumerDomu = 5,
                    NumerMieszkania = null
                }
            };

            Console.WriteLine(jk.ToString());
            Osoba jkb = jk;
            Console.WriteLine(jkb.ToString());

            List<Figura> figury = new List<Figura>();
            figury.Add(new Okrag());
            figury.Add(new Trojkat());
            figury.Add(new Prostokat());
            figury.Add(new Kwadrat());
            foreach (Figura figura in figury)
                Console.WriteLine("Figura " + figura.GetType().Name + " ma " + figura.IleWierzcholkow() + " wierzcholkow.");

            List<IPosiadaTelefonStacjonarny> listaTelefonów = new List<IPosiadaTelefonStacjonarny>();
            listaTelefonów.Add(new OsobaZameldowana() { NumerTelefonu = 123456789 });
            listaTelefonów.Add(new OsobaZameldowana() { NumerTelefonu = 987654321 });
            foreach (IPosiadaTelefonStacjonarny telefon in listaTelefonów)
                WyświetlNumerTelefonu(telefon);

            Console.ReadKey();
        }

        static void WyświetlIlośćWierzchołków(Figura figura)
        {
            Console.WriteLine("Liczba wierzchołków figury: " + figura.IleWierzcholkow());
        }
    }
}
