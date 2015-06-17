using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_równoległe
{
    class Program
    {
        static private double obliczenia(double argument)
        {
            for (int i = 0; i < 10; ++i)
            {
                argument = Math.Asin(Math.Sin(argument));
            }

            return argument;
        }

        static void Main(string[] args)
        {
            //przygotowania
            int rozmiar = 10000;
            Random r = new Random();
            double[] tablica = new double[rozmiar];
            for (int i = 0; i < tablica.Length; ++i) tablica[i] = r.NextDouble();

            //obliczenia sekwencyjne
            int liczbaPowtorzen = 100;
            double[] wyniki = new double[tablica.Length];
            int start = System.Environment.TickCount;
            for (int powtorzenia = 0; powtorzenia < liczbaPowtorzen; ++powtorzenia)
            {
                Parallel.For(0, tablica.Length, (int i) => wyniki[i] = obliczenia(tablica[i]));
            }
                //for (int i = 0; i < tablica.Length; ++i)
                //    wyniki[i] = obliczenia(tablica[i]);
            int stop = System.Environment.TickCount;
            Console.WriteLine("Obliczenia sekwencyjne trwaly " + (stop - start).ToString() + " ms.");

            //prezentacja wyników
            //Console.WriteLine("Wynik:");
            //for (long i = 0; i < tablica.Length; ++i)
            //    Console.WriteLine(i + ". " + tablica[i] + " ?= " + wyniki[i]);

            Console.ReadKey();
        }
    }
}
