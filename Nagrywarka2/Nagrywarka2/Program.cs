using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagrywarka2
{
    class Program
    {
        public static Nagrywarka s = new Nagrywarka();
        public static NagrywarkaZPamięcią szpamiecia = new NagrywarkaZPamięcią();
        public static Nagranie nags;

        static void Main()
        {
            Console.WriteLine("Podaj miejsce nagrywania: DVD/HDD");
            string choice1 = Console.ReadLine();

            do
            {
                if (choice1 == "DVD")
                {
                    s.mN = 1;
                    Console.WriteLine("Wybrales DVD");
                    Console.WriteLine("{0}", s.mN);

                    s.Włącz();
                    Console.WriteLine("Co chcesz zrobic:\nOdtwarzanie\nNagrywanie");
                    choice1 = Console.ReadLine();
                    //szpamiecia.wypisz();
                    wybór(choice1);
                }
                else if (choice1 == "HDD")
                {
                    s.mN2 = 2;
                    Console.WriteLine("Wybrales HDD");
                    Console.WriteLine("{0}", s.mN2);

                    s.Włącz();
                    Console.WriteLine("Co chcesz zrobic:\nOdtwarzanie\nNagrywanie");
                    choice1 = Console.ReadLine();
                    //szpamiecia.wypisz();
                    wybór(choice1);
                }
                else if (wybór(choice1) == 1)
                {
                    Console.ReadKey();
                }
            } while (wybór(choice1) != 1);
        }

        public static int wybór(string choice)
        {

            if (choice == "Odtwarzanie")
            {
                if (s.Odtwarzaj() == 1)
                    return 1;
                return s.Odtwarzaj();
            }
            else if (choice == "Nagrywanie")
            {
                return s.Nagrywaj();
            }
            else
                return 0;
        }
    }

    class Nagrywarka
    {
        //pola
        public enum miejsceNagrywania { DVD, HDD };
        public int mN = (int)miejsceNagrywania.DVD;
        public int mN2 = (int)miejsceNagrywania.HDD;
        public enum stan { Wyłączone, Zatrzymane, Nagrywanie, Odtwarzanie };
        public int stan1 = (int)stan.Wyłączone;
        public int stan2 = (int)stan.Zatrzymane;
        public int stan3 = (int)stan.Nagrywanie;
        public int stan4 = (int)stan.Odtwarzanie;

        //metody
        public int Włącz()
        {
            Console.WriteLine("\nWlaczone");

            stan1 = 0;
            stan2 = 0;
            stan3 = 0;
            stan4 = 0;

            return 0;
        }

        public virtual int Odtwarzaj()
        {
            Console.WriteLine("\nOdtwarzanie");

            stan1 = 0;
            stan2 = 0;
            stan3 = 0;
            stan4 = 1;

            Console.WriteLine("\nCo chcesz zrobic?\nZatrzymac\nKontynuuj");
            string choice2 = Console.ReadLine();
            if (choice2 == "Zatrzymac")
            {
                if (Zatrzymaj() == 1)
                    return 1;
            }
            else
                Odtwarzaj();

            return 0;
        }

        public virtual int Nagrywaj()
        {
            Console.WriteLine("\nNagrywanie");

            stan1 = 0;
            stan2 = 0;
            stan3 = 1;
            stan4 = 0;

            Console.WriteLine("\nCo chcesz zrobic?\nZatrzymac\nKontynuowac");
            string choice2 = Console.ReadLine();
            if (choice2 == "Zatrzymac")
            {
                if (Zatrzymaj() == 1)
                    return 1;
            }
            else
                Odtwarzaj();

            return 2;
        }

        public virtual int Zatrzymaj()
        {
            Console.WriteLine("\nZatrzymanie");

            stan1 = 0;
            stan2 = 1;
            stan3 = 0;
            stan4 = 0;

            Console.WriteLine("Chcesz wznowic czy wylaczyc?\nWznow\nWylacz");
            string choice2 = Console.ReadLine();
            if (choice2 == "Wznow")
                return Odtwarzaj();
            else if (choice2 == "Wylacz")
            {
                stan1 = 1;
                return stan1;
            }

            return 0;
        }
    }

    class Nagranie
    {
        //pola
        public int numerNagrania { get; set; }
        public DateTime dataRozpoczęcia { get; set; }
        public int czasRozpoczęciaNagrywania { get; set; }
        public int czasZakończeniaNagrywania { get; set; }

        public Nagranie(int nrNagrania, DateTime dR, int czasRN, int czasZN)
        {
            numerNagrania = nrNagrania;
            dataRozpoczęcia = dR;
            czasRozpoczęciaNagrywania = czasRN;
            czasZakończeniaNagrywania = czasZN;
        }
    }

    class NagrywarkaZPamięcią : Nagrywarka
    {
        //pola
        public static List<Nagranie> nagranie = new List<Nagranie>();
        public static Nagranie nagr;
        public static DateTime dr = nagr.dataRozpoczęcia.Date;
        public static int crn = nagr.czasRozpoczęciaNagrywania;
        public static int czn = nagr.czasZakończeniaNagrywania;

        //metody
        public void wypisz()
        {
            nagranie.Add(new Nagranie(1, dr, crn, czn));
            nagranie.Add(new Nagranie(2, dr, crn, czn));
            nagranie.Add(new Nagranie(3, dr, crn, czn));
            nagranie.Add(new Nagranie(4, dr, crn, czn));
            nagranie.Add(new Nagranie(5, dr, crn, czn));
            nagranie.Add(new Nagranie(6, dr, crn, czn));
            nagranie.Add(new Nagranie(7, dr, crn, czn));
            nagranie.Add(new Nagranie(8, dr, crn, czn));
            nagranie.Add(new Nagranie(9, dr, crn, czn));
            nagranie.Add(new Nagranie(10, dr, crn, czn));

            //wypisanie listy nagranie
            foreach (Nagranie nag in nagranie)
                Console.WriteLine("Numer nagrania: " + nag.numerNagrania +
                    ", Data rozpoczecia: " + nag.dataRozpoczęcia +
                    ", Czas rozpoczecia nagrywania: " + nag.czasRozpoczęciaNagrywania +
                    "Czas Zakonczenia nagrywania: " + nag.czasZakończeniaNagrywania);
        }
    }
}