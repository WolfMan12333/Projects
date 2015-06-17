using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poczta
{
    class Program
    {
        static void Main(string[] args)
        {
            Adres ad = new Adres();
            ad.Kraj = "Polska";
            ad.Miasto = "Glogoczow";
            ad.Ulica = new KodPocztowy();
           
            Console.WriteLine(ad.ToString());
            Console.ReadKey();
        }
    }

    class KodPocztowy
    {
        //pola
        int OkręgPocztowy;
        int SektorKodowy;

        //metoda
        public override string ToString()
        {
            return OkręgPocztowy.ToString() + "' " + SektorKodowy.ToString();
        }
    }

    class Adres
    {
        //pola
        public string Kraj;
        public string Miasto;
        public KodPocztowy Ulica;

        //metoda
        public override string ToString()
        {
            return Kraj + " " + Miasto + " " + Ulica;
        }
    }
}
