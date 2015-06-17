using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ
{
    class Osoba
    {
        public int Id;
        public string Imie, Nazwisko;
        public int NumerTelefonu;
        public int Wiek;
    }

    class Program
    {
        //źródło danych
        static List<Osoba> listaOsob = new List<Osoba>
        {
            new Osoba { Id = 1, Imie = "Jan" , Nazwisko = "Kowalski", NumerTelefonu = 7272024, Wiek = 39},
            new Osoba { Id = 2, Imie = "Andrzej", Nazwisko = "Kowalski", NumerTelefonu = 7272020, Wiek = 29},
            new Osoba { Id = 3, Imie = "Maciej", Nazwisko = "Bartnicki", NumerTelefonu = 7272021, Wiek = 42},
            new Osoba { Id = 4, Imie = "Witold", Nazwisko = "Mocarz", NumerTelefonu = 7272022, Wiek = 26},
            new Osoba { Id = 5, Imie = "Adam", Nazwisko = "Kowalski", NumerTelefonu = 7272023, Wiek = 6},
            new Osoba { Id = 6, Imie = "Ewa", Nazwisko = "Mocarz", NumerTelefonu = 7272025, Wiek = 11}
        };

        static void Main(string[] args)
        {
            var listaOsobPelnoletnich = from osoba in listaOsob
                                        where osoba.Wiek >= 18
                                        orderby osoba.Wiek
                                        //select new { osoba.Imie, osoba.Nazwisko, osoba.Wiek };
                                        select osoba;

            List<Osoba> podlista = listaOsobPelnoletnich.ToList<Osoba>();

            Console.WriteLine("Lista osob pelnoletnich: ");
            foreach (var osoba in listaOsobPelnoletnich)
                Console.WriteLine(osoba.Imie + " " + osoba.Nazwisko + " (" + osoba.Wiek + ")");

            Console.WriteLine("Wiek najstarszej osoby: " + listaOsobPelnoletnich.Max(osoba => osoba.Wiek));
            Console.WriteLine("Sredni wiek osob pelnoletnich: " + listaOsobPelnoletnich.Average(osoba => osoba.Wiek));
            Console.WriteLine("Suma lat osob pelnoletnich: " + listaOsobPelnoletnich.Sum(osoba => osoba.Wiek));

            var najstarszaOsoba = listaOsobPelnoletnich.Single(
                osoba1 => (osoba1.Wiek == listaOsobPelnoletnich.Max(osoba => osoba.Wiek)));
            //label1.Text += "<p>Najstarsza osoba: " + najstarszaOsoba.Imie + " " + najstarszaOsoba.Nazwisko + " (" + najstarszaOsoba.Wiek + ")";

            bool czyWszystkiePelnoletnie = listaOsobPelnoletnich.All(osoba => (osoba.Wiek > 18));

            bool czyZawieraPelnoletnia = listaOsob.Any(osoba => (osoba.Wiek > 18));

            var grupyOsobOTYmSamymNazwisku = from osoba in listaOsob
                                             group osoba by osoba.Nazwisko into grupa
                                             select grupa;
            Console.WriteLine("Lista osob pogrupowanych wedlug nazwisk: ");
            foreach(var grupa in grupyOsobOTYmSamymNazwisku)
            {
                Console.WriteLine("Grupa osob o nazwisku " + grupa.Key);
                foreach (Osoba osoba in grupa) Console.WriteLine(osoba.Imie + " " + osoba.Nazwisko);
                Console.WriteLine();
            }

            var listaOsobPelnoletnich2 = from osoba in listaOsob
                                         where osoba.Wiek >= 18
                                         orderby osoba.Wiek
                                         select new { osoba.Imie, osoba.Nazwisko, osoba.Wiek };
            var listaKobiet = from osoba in listaOsob
                             where osoba.Imie.EndsWith("a")
                             select new { osoba.Imie, osoba.Nazwisko, osoba.Wiek };

            var listaPelnoletnich_I_Kobiet = listaOsobPelnoletnich2.Concat(listaKobiet);

            var listaPelnoletnich_I_Kobiet2 = listaOsobPelnoletnich2.Concat(listaKobiet).Distinct();

            var listaKobietPelnoletich = listaOsobPelnoletnich2.Intersect(listaKobiet);

            var listaPelnoletnichNiekobiet = listaOsobPelnoletnich2.Except(listaKobiet);

            var listaTelefonow = from osoba in listaOsob
                                 select new { osoba.Id, osoba.NumerTelefonu };
            var listaPersonaliow = from osoba in listaOsob
                                   select new { osoba.Id, osoba.Imie, osoba.Nazwisko };

            var listaPersonaliowZTelefonami = from telefon in listaTelefonow
                                              join personalia in listaPersonaliow
                                              on telefon.Id equals personalia.Id
                                              select new
                                                  {
                                                      telefon.Id,
                                                      personalia.Imie,
                                                      personalia.Nazwisko,
                                                      telefon.NumerTelefonu
                                                  };

            var nowaListaOsobPelnoletnich = from osoba in listaOsob
                                            where osoba.Wiek >= 18
                                            orderby osoba.Wiek
                                            select osoba;

            Osoba pierwszyNaLiscie = nowaListaOsobPelnoletnich.First<Osoba>();
            pierwszyNaLiscie.Imie = "Karol";
            pierwszyNaLiscie.Nazwisko = "Bartnicki";
            pierwszyNaLiscie.Wiek = 31;

            foreach (var osoba in nowaListaOsobPelnoletnich)
                Console.WriteLine(osoba.Imie + " " + osoba.Nazwisko + " (" + osoba.Wiek + ")");



            Console.ReadKey();
        }
    }
}
