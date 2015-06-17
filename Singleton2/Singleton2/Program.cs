using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton2
{
    class Program
    {
        static void Main(string[] args)
        {
            KlasaStatyczna.Własność = "Wartosc pola ustalona w metodzie Program.Main";
            KlasaStatyczna.Metoda();

            InstancjaWStatycznymPolu.Instancja.Własność = "Wartosc pola ustalona w metodzie Program.Main";
            InstancjaWStatycznymPolu.Instancja.Metoda();

            InstancjaWStatycznymPolu referencja = InstancjaWStatycznymPolu.Instancja;
            referencja.Własność = "Wartość pola ustalona w metodzie Program.Main";

            KontrolaLiczbyInstancji inst = KontrolaLiczbyInstancji.Instancja;
            inst.Własność = "Wartość pola ustalona w metodzie Program.Main";

            Console.ReadKey();
        }
    }
    
    //Singleton jako klasa statyczna
    public static class KlasaStatyczna
    {
        private static string pole = "Domyslna wartosc pola";

        public static string Własność
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

    //Singleton jako pole statyczne z kontrolą dostępu
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

        public string Własność
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

        private string pole = "Domyślna wartosc pola";

        public string Własność
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
}
