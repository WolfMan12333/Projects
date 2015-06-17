using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoba
{
    class Program
    {
        static void Main(string[] args)
        {
            //źródło danych 
            List<Osoba> listaOsob = new List<Osoba>
            {
                new Osoba {Id = 1, Imię = "Jan", Nazwisko = "Kowalski", NumerTelefonu = 7272024, Wiek = 39},
                new Osoba {Id = 2, Imię = "Andrzej", Nazwisko = "Kowalski", NumerTelefonu = 7272020, Wiek = 29},
                new Osoba {Id = 3, Imię = "Maciej", Nazwisko = "Bartnicki", NumerTelefonu = 7272021, Wiek = 42},
                new Osoba {Id = 4, Imię = "Witold", Nazwisko = "Mocarz", NumerTelefonu = 7272022, Wiek = 26},
                new Osoba {Id = 5, Imię = "Adam", Nazwisko = "Kowalski", NumerTelefonu = 7272023, Wiek = 6},
                new Osoba {Id = 6, Imię = "Ewa", Nazwisko = "Mocarz", NumerTelefonu = 7272025, Wiek = 11},
                new Osoba {Id = 7, Imię = "Dawid", Nazwisko = "Wordliczek", NumerTelefonu = 663676742, Wiek = 23}
            };

            var listaOsobPelnoletnich = from osoba in listaOsob
                                        where osoba.Wiek >= 18
                                        orderby osoba.Wiek
                                        select osoba;

            Console.WriteLine("Lista osob pelnoletnich:");
            foreach (var osoba in listaOsobPelnoletnich)
                Console.WriteLine(osoba.Imię + " " + osoba.Nazwisko + " (" + osoba.Wiek + ")");

            Console.WriteLine("Wiek najstarszej osoby:" + listaOsobPelnoletnich.Max(osoba => osoba.Wiek));
            Console.WriteLine("Sredni wiek osob pelnoletnich: " + listaOsobPelnoletnich.Average(osoba => osoba.Wiek));
            Console.WriteLine("Suma lat osob pelnoletnich: " + listaOsobPelnoletnich.Sum(osoba => osoba.Wiek));

            var najstarszaOsoba = listaOsobPelnoletnich.Single(osoba1 =>(osoba1.Wiek == listaOsobPelnoletnich.Max(osoba => osoba.Wiek)));
            bool czyWszystkiePelnoletnie = listaOsobPelnoletnich.All(osoba => osoba.Wiek >= 18);
            bool czyZawieraPelnoletnia = listaOsob.Any(osoba => (osoba.Wiek >= 18));

            var grupyOsobOTymSamymNazwisku = from osoba in listaOsob
                                             group osoba by osoba.Nazwisko into grupa
                                             select grupa;
            Console.WriteLine("Lista osob pogrupowanych wedlug nazwisk:");
            foreach (var grupa in grupyOsobOTymSamymNazwisku)
            {
                Console.WriteLine("Grupa osob o nazwisku " + grupa.Key);
                foreach (Osoba osoba in grupa) Console.WriteLine(osoba.Imię + " " + osoba.Nazwisko);
                Console.WriteLine();
            }

            var listaKobiet = from osoba in listaOsob
                              where osoba.Imię.EndsWith("a")
                              select new {osoba.Imię, osoba.Nazwisko, osoba.Wiek};
            foreach (var osoba in listaKobiet)
                Console.WriteLine(osoba.Imię + " " + osoba.Nazwisko + " " + osoba.Wiek);

            //var listaPelnoletnich_I_Kobiet = listaOsobPelnoletnich.Concat(listaKobiet);
            //foreach (var osoba in listaPelnoletnich_I_Kobiet)
            //    Console.WriteLine(osoba.)

            var listaTelefonów = from osoba in listaOsob
                                 select new {osoba.Id, osoba.NumerTelefonu};
            foreach (var osoba in listaTelefonów)
                Console.WriteLine(osoba.Id + " nr. tel.:" + osoba.NumerTelefonu);

            var listaPersonaliów = from osoba in listaOsob
                                   select new {osoba.Id, osoba.Imię, osoba.Nazwisko};
            foreach (var osoba in listaPersonaliów)
                Console.WriteLine(osoba.Id + " " + osoba.Imię + " " + osoba.Nazwisko);

            var listaPersonaliówZTelefonami = from osoba in listaTelefonów
                                              join personalia in listaPersonaliów
                                              on osoba.Id equals personalia.Id
                                              select new
                                                  {
                                                      osoba.Id,
                                                      personalia.Imię,
                                                      personalia.Nazwisko,
                                                      osoba.NumerTelefonu
                                                  };
            foreach (var osoba in listaPersonaliówZTelefonami)
                Console.WriteLine(osoba.Id + " " + osoba.Imię + " " + osoba.Nazwisko + " " + osoba.NumerTelefonu);

            //****************************************************************************************************
            //osoby zameldowane
            List<OsobaZameldowana> osobazameldowana = new List<OsobaZameldowana>
            {
                new OsobaZameldowana{Id = 1, Imię = "Dawid", Nazwisko = "Wordliczek", NumerTelefonu = 663676742, Wiek = 23},
                new OsobaZameldowana{Id = 2, Imię = "Monika", Nazwisko = "Szywalska", NumerTelefonu = 123456789, Wiek = 22},
                new OsobaZameldowana{Id = 3, Imię = "Dariusz", Nazwisko = "Plotka", NumerTelefonu = 0700880774, Wiek = 18},
                new OsobaZameldowana{Id = 4, Imię = "Seweryn", Nazwisko = "Plotka", NumerTelefonu = 122346235, Wiek = 25},
                new OsobaZameldowana{Id = 5, Imię = "Wojtek", Nazwisko = "Szywalski", NumerTelefonu = 235686987, Wiek = 35},
                new OsobaZameldowana{Id = 6, Imię = "Monika", Nazwisko = "Moniś", NumerTelefonu = 23530980, Wiek = 26},
                new OsobaZameldowana{Id = 7, Imię = "Moniś", Nazwisko = "Szywalska", NumerTelefonu = 252353513, Wiek = 22}
            };

            var lista = from osoba in osobazameldowana
                        join wiek in listaOsobPelnoletnich
                        on osoba.Id equals wiek.Id
                        select new
                            {
                                osoba.Id,
                                osoba.Imię,
                                osoba.Nazwisko,
                                osoba.NumerTelefonu,
                                osoba.Wiek
                            };

            foreach (var osoba in lista)
                Console.WriteLine(osoba.Id + " " + osoba.Imię + " " + osoba.Nazwisko + " " + osoba.NumerTelefonu + " " + osoba.Wiek);

            var listakobietpowyzejczterdziestu = from osoba in listaKobiet
                                                 where osoba.Wiek > 40
                                                 select new { osoba.Imię, osoba.Nazwisko, osoba.Wiek };
            foreach (var osoba in listakobietpowyzejczterdziestu)
                Console.WriteLine(osoba.Imię + " " + osoba.Nazwisko + " " + osoba.Wiek);

            var listamezczyzn = from osoba in listaOsobPelnoletnich
                                where  !osoba.Imię.EndsWith("a")
                                select new { osoba.Id, osoba.Imię, osoba.Nazwisko, osoba.Wiek, osoba.NumerTelefonu };
            foreach (var osoba in listamezczyzn)
                Console.WriteLine(osoba.Id + " " + osoba.Imię + " " + osoba.Nazwisko + " " + osoba.NumerTelefonu + " " + osoba.Wiek);

            var listakobietbeza = from osoba in listaKobiet
                                  where osoba.Nazwisko.EndsWith("a")
                                  select new { osoba.Imię, osoba.Nazwisko, osoba.Wiek };
            foreach (var osoba in listakobietbeza)
                Console.WriteLine(osoba.Imię + " " + osoba.Nazwisko + " " + osoba.Wiek);

            foreach (var osoba in listaOsob)
                Console.WriteLine();

            Console.ReadKey();
        }
    }

    class Osoba : IPosiadajacyAdresEmail
    {
        public int Id;
        public string Imię, Nazwisko;
        public int NumerTelefonu;
        public int Wiek;

        public string ade;

        public string AdresEmail
        {
            get
            {
                return ade;
            }
            set
            {
                ade = value;
            }
        }

        public bool czyjestadresemail
        {
            get
            {
                return ade != "";
            }
        }
    }

    class OsobaZameldowana : Osoba
    {}

    interface IPosiadajacyAdresEmail
    {
        string AdresEmail { get; set; }
    }
}
