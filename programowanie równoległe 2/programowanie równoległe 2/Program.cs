using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programowanie_równoległe_2
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
            Random r = new Random();
            long suma = 0;
            long licznik = 0;
            string s = "";

            //iteracje zostaną wykonane tylko dla liczb parzystych
            //pętla zostanie przerwana wczesniej, jeżeli wylosowana liczba jest równa 0
            Parallel.For(0, 10000, (int i, ParallelLoopState stanPetli) =>
                {
                    int liczba = r.Next(7); //losowanie liczby oczek na kostce
                    if (liczba == 0)
                    {
                        s += "Stop:";
                        stanPetli.Stop();
                    }
                    if (stanPetli.IsStopped) return;
                    if (liczba % 2 == 0)
                    {
                        s += liczba.ToString() + "; ";
                        obliczenia(liczba);
                        suma += liczba;
                        licznik++;
                    }
                    else
                        s += "[" + liczba.ToString() + "]; ";
                });

            Console.WriteLine("Wylosowane liczby: " + s + "\nLiczba pasujacych liczb: " + licznik + "\nSuma: " + suma + "\nSrednia: " + (suma / (double)licznik).ToString());

            Console.ReadKey();
        }
    }
}
