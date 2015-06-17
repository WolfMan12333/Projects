using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    //Singleton jako klasa statyczna
    public static class KlasaStatyczna
    {
        private static string pole = "Domyslna wartosc pola";

        public static string Wlasnosc
        {
            get
            {
                return pole;
            }
            set
            {
                pole = value;
            }
        }

        public static void Metoda()
        {
            Console.WriteLine(pole);
        }
    }

    //Singleton jako pole statyczne z kotrolą dostępu
    public sealed class InstancjaWStatycznymPolu
    {
        private static readonly InstancjaWStatycznymPolu instancja = new InstancjaWStatycznymPolu();

        private InstancjaWStatycznymPolu() { } //ukryty konstruktor

        public static InstancjaWStatycznymPolu Instancja
        {
            get
            {
                return instancja;
            }
        }

        private string pole = "Domyslna wartosc pola";

        public string Wlasnosc
        {
            get
            {
                return pole;
            }
            set
            {
                pole = value;
            }
        }

        public void Metoda()
        {
            Console.WriteLine(pole);
        }
    }

    //Singleton - kontrola liczby tworzonych instancji
    public sealed class KontrolaLiczbyInstancji
    {
        private static KontrolaLiczbyInstancji instancja;

        private KontrolaLiczbyInstancji() { }

        public static KontrolaLiczbyInstancji Instancja
        {
            get
            {
                if (instancja == null) instancja = new KontrolaLiczbyInstancji();

                return instancja;
            }
        }

        private string pole = "Domyslna wartosc pola";

        public string Wlasnosc
        {
            get
            {
                return pole;
            }
            set
            {
                pole = value;
            }
        }

        public void Metoda()
        {
            Console.WriteLine(pole);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //klasa statyczna singleton
            KlasaStatyczna.Wlasnosc = "Wartosc pola ustalona w metodzie Program.Main";
            KlasaStatyczna.Metoda();

            //singleton jako pole statyczne z kontrolą dostępu
            InstancjaWStatycznymPolu.Instancja.Wlasnosc = "Wartosc pola ustalona w metodzie Program.Main";
            InstancjaWStatycznymPolu.Instancja.Metoda();

            //singleton jako pole statyczne z kontrolą dostępu poprzez zmienną referencyjną 
            InstancjaWStatycznymPolu referencja = InstancjaWStatycznymPolu.Instancja;
            referencja.Wlasnosc = "Wartosc pola ustalona w metodzie Program.Main";

            //Singleton - kotrola liczby tworzonych instancji

            Console.ReadKey();
        }
    }
}
