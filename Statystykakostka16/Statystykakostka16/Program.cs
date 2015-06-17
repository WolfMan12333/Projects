using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statystykakostka16
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            int[] tab = new int[i];
            Console.WriteLine("Podaj ile razy chcesz przeprowadzic losowanie: ");
            int s;
            s = int.Parse(Console.ReadLine());
            Random rand = new Random();
            for (int z = 0; z < tab.Length; ++z)
            {
                tab = new int[s];
                int b;
                b = rand.Next(1, 6);
                tab[z] = b;
            }
            //Console.WriteLine("Tablica:");
            //for (int ia = 0; ia < tab.Length; ++ia)
            //    Console.WriteLine(tab[ia]);
            //średnia
            int srednia = 0;
            for (int z = 0; z < tab.Length; ++z)
                srednia += tab[z];

            srednia = srednia / tab.Length;

            Console.WriteLine("Srednia wynosi: " + srednia);

            //miediana
            if (s % 2 == 0)
            {
                int sred = 0;
                for (int z = 0; z < tab.Length; ++z)
                    sred += tab[z];

                sred = sred / tab.Length;

                Console.WriteLine("Mediana wynosi: " + sred);
            }
            else 
                if (s % 2 == 1)
                {
                    int pol = tab.Length / 2;
                    int pop = pol - 1;
                    int nast = pol + 1;

                    if (tab[pol] > tab[pop] && tab[pol] < tab[nast])
                        Console.WriteLine("Mediana wynosi: " + tab[pol]);
                    else if (tab[pop] > tab[pol] && tab[pop] < tab[nast])
                        Console.WriteLine("Mediana wynosi: " + tab[pop]);
                    else if (tab[nast] > tab[pop] && tab[nast] < tab[pol])
                        Console.WriteLine("Mediana wynosi: " + tab[nast]);
                }

            //wariancja
            int war = 0;
            for (int z = 0; z < tab.Length; ++z)
            {
                war += (tab[z] - srednia);
            }

            Console.WriteLine("Wariancja: " + war);
            Console.ReadKey();
        }
    }
}
