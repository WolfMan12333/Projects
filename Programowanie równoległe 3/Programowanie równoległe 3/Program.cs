using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_równoległe_3
{
    class Program
    {
        Task<long> ZrobCosAsync(object argument)
        {
            //czynność, któa będzie wykonywana asynchronicznie
            Func<object, long> akcja =
                (object _argument) =>
                {
                    Console.WriteLine("Poczatke dzialania akcji - " + _argument.ToString());
                    System.Threading.Thread.Sleep(500); //opóźnienie 0.5s
                    Console.WriteLine("Koniec dzialania akcji - " + _argument.ToString());
                    return DateTime.Now.Ticks;
                };

            Task<long> zadanie = new Task<long>(akcja, argument);
            zadanie.Start();
            return zadanie;
        }

        static async void ProgramowanieAsynchroniczne()
        {
            Task<long> zadanie2 = ZrobCosAsync("zadanie-metoda");
            Console.WriteLine("Akcja zostala uruchomiona (metoda)");
            long wynik = await zadanie2;
            Console.WriteLine("Zadanie-metoda: " + wynik.ToString());
        }

        static void Main(string[] args)
        {
            //czynność
            //Func<object, long> akcja =
            //    (object argument) =>
            //    {
            //        Console.WriteLine("Poczatek dzialania akcji - " + argument.ToString());
            //        System.Threading.Thread.Sleep(500); //opóźnienie 0.5s
            //        Console.WriteLine("Koniec dzialania akcji - " + argument.ToString());
            //        return DateTime.Now.Ticks;
            //    };

            ////long wynik = akcja("synchronicznie");
            ////Console.WriteLine("Synchronicznie: " + wynik.ToString());

            ////w osobnym zadaniu 
            //Task<long> zadanie = new Task<long>(akcja, "zadanie");
            //zadanie.Start();
            //Console.WriteLine("Akcja zostala uruchomiona");
            ////właściwość Result czeka ze zwróceniem wartości, aż zadanie zostanie zakończone
            ////(synchronizacja)
            //long wynik = zadanie.Result;
            //Console.WriteLine("Zadanie: " + wynik.ToString());

            //Task<long> zadanie2 = ZrobCosAsync("zadanie-metoda");
            //Console.WriteLine("Akcja została uruchomiona (metoda)");
            //long wynik = zadanie2.Result;
            //Console.WriteLine("Zadanie-metoda: " + wynik.ToString());

            ProgramowanieAsynchroniczne();
            Console.WriteLine();

            Console.WriteLine("Nacisnij Enter...");

            Console.ReadLine();
        }
    }
}
