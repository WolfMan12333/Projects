using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegacje_i_zdarzenia
{
    class Klasa
    {
        public delegate void Callback(object sender, DateTime czasZakonczeniaMetody);

        public Callback DelegacjaMetodaZakonczona;
        public event Callback ZdarzenieMetodaZakonczona;

        public void Metoda()
        {
            Console.WriteLine("Metoda - początek");

            //tudługie działanie metody

            Console.WriteLine("Metoda - tuż przed końcem");

            if (DelegacjaMetodaZakonczona != null)
                DelegacjaMetodaZakonczona(this, DateTime.Now);
            if (ZdarzenieMetodaZakonczona != null)
                ZdarzenieMetodaZakonczona(this, DateTime.Now);

            Console.WriteLine("Metoda - koniec");
        }
    }

    class Program
    {
        static private void obiekt_MetodaZakonczona(object sender, DateTime czasZakonczeniaMetody)
        {
            Console.WriteLine("Zakonczona metoda obiektu typu " + sender.GetType().Name + " (czas: " + czasZakonczeniaMetody.ToString() + ")");
        }

        static void Main(string[] args)
        {
            Klasa obiekt = new Klasa();

            //subskrypcja
            obiekt.DelegacjaMetodaZakonczona = obiekt_MetodaZakonczona;
            obiekt.ZdarzenieMetodaZakonczona += obiekt_MetodaZakonczona;

            //uruchomenie metody, która wywoła metodę zdarzeniową
            obiekt.Metoda();

            obiekt.DelegacjaMetodaZakonczona(obiekt, DateTime.Now); //symulacja zdarzenia
            if (obiekt.DelegacjaMetodaZakonczona == null)
                Console.WriteLine("Delegacja nieprzypisana");

            Console.ReadKey();
        }
    }
}
