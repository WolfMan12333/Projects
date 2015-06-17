using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiagFibonacciego
{
    class Program
    {
        public static void CiagFibonacciego(uint[] tab)
        {
            for (uint i = 1; i <= 20; ++i)
            {
                if (i == 1 || i == 2)
                {
                    tab[i] = 1;
                    Console.WriteLine(i + "= " + "1");
                }
                else
                    Console.WriteLine(i + "= " + (tab[i] = tab[i - 1] + tab[i - 2]));
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbe ktora chcesz uzyc przy Ciagu Fibonacciego:\n");
            uint[] tab = new uint[21];
            Console.WriteLine("Ciag Fibonacciego w tablicy 20 elementow:\n");
            CiagFibonacciego(tab);
            Console.ReadKey();
        }
    }
}
