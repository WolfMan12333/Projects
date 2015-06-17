using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasybazoweipotomne
{
    abstract class Figura
    {
        public Figura()
        {
            Console.WriteLine("Konstruktor klasy Figura");
        }

        public Figura(string argument)
        {
            Console.WriteLine("Konstruktor klasy Figura, komunikat: " + argument);
        }

        public abstract int IleWierzcholkow();

        public virtual int LiczbaWierzcholkow
        {
            get
            {
                return IleWierzcholkow();
            }
        }
    }

    class Okrag : Figura
    {
        public override int IleWierzcholkow()
        {
            return 0;
        }
    }

    class Trojkat : Figura
    {
        public Trojkat()
        {
            Console.WriteLine("Konstruktor klasy Trojkat");
        }

        //public Trojkat(string argument)
        //{
        //    Console.WriteLine("Konstruktor klasy Trojkat, komunikat: " + argument);
        //}

        public Trojkat(string argument) : base(argument)
        {
            Console.WriteLine("Konstruktor klasy Trojkat, komunikat: " + argument);
        }

        public override int IleWierzcholkow()
        {
            return 3;
        }
    }

    class Prostokat : Figura
    {
        public override int IleWierzcholkow()
        {
            return 4;
        }
    }

    class Kwadra : Prostokat { }

    interface IPosiadaTelefonStacjonarny
    {
        int? NumerTelefonu { get; set; }
    }

    class Osoba
    {
        public string Imie;
        public string Nazwisko;
        public int Wiek;

        public override string ToString()
        {
            return Imie + " " + Nazwisko + " (" + Wiek + ")";
        }

        public string Personalia
        {
            get
            {
                return Imie + " " + Nazwisko;
            }
        }
    }

    class Adres
    {
        public string Miasto;
        public string Ulica;
        public int NumerDomu;
        public int? NumerMieszkania;

        public override string ToString()
        {
            return Miasto + ", ul. " + Ulica + " " + NumerDomu + (NumerMieszkania.HasValue ? ("/" + NumerMieszkania) : "");
        }
    }

    class OsobaZameldowana : Osoba, IPosiadaTelefonStacjonarny
    {
        public Adres AdresZameldowania;

        public virtual string ToString()
        {
            return base.ToString() + "; " + AdresZameldowania.ToString();
        }

        private int? numerTelefonu;

        public int? NumerTelefonu
        {
            get
            {
                return numerTelefonu;
            }
            set 
            {
                numerTelefonu = value;
            }
        }

        public bool CzyPosiadaTelefonStacjonarny
        {
            get
            {
                return numerTelefonu.HasValue;
            }
        }
    }

    class Program
    {
        static void WyswietlIloscWierzcholkow(Figura figura)
        {
            Console.WriteLine("Liczba wierzcholkow figury: " + figura.IleWierzcholkow());
        }

        static void WyswietlNumerTelefonu(IPosiadaTelefonStacjonarny telefon)
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
                    Miasto = "Toruń",
                    Ulica = "Grudziądzka",
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
            figury.Add(new Kwadra());

            foreach (Figura figura in figury)
                Console.WriteLine("Figura " + figura.GetType().Name +" ma " + figura.IleWierzcholkow() + " wierzchołków.");

            List<IPosiadaTelefonStacjonarny> listaTelefonow = new List<IPosiadaTelefonStacjonarny>();
            listaTelefonow.Add(new OsobaZameldowana() { NumerTelefonu = 123456789 });
            listaTelefonow.Add(new OsobaZameldowana() { NumerTelefonu = 987654321 });
            foreach (IPosiadaTelefonStacjonarny telefon in listaTelefonow)
                WyswietlNumerTelefonu(telefon);

            Console.ReadKey();
        }
    }
}
